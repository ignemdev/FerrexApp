using Ferrex.Core;
using Ferrex.Core.Models;
using Ferrex.Services.Handlers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Ferrex.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment
            )
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index() => View();

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            if (!id.HasValue) return View(new Product());

            var dbProduct = await _unitOfWork.Product.GetByIdAsync(id.GetValueOrDefault());

            if (dbProduct is not null) return View(dbProduct);
            else return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(WebImageHandler webImageHandler, Product product)
        {
            if (ModelState.IsValid)
            {
                var webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                var dbProduct = (product.Id != 0) ? await _unitOfWork.Product.GetByIdAsync(product.Id) : null;

                switch (files.Count)
                {
                    case 0:
                        if (dbProduct is not null) product.Image ??= dbProduct.Image;
                        break;

                    default:
                        webImageHandler.FormFile = files[0];
                        webImageHandler.CopyImage(product.Name, true, webRootPath, @"imgs\products\");
                        product.Image = $"{webImageHandler.ImageName}.{webImageHandler.ImageExtension}";

                        if (dbProduct is not null)
                        {
                            if (!string.IsNullOrWhiteSpace(dbProduct.Image))
                                webImageHandler.DeleteImage(webRootPath, @"imgs\products\", dbProduct.Image);
                        }
                        break;
                }

                if (product.Id == 0) await _unitOfWork.Product.AddAsync(product);
                else await _unitOfWork.Product.UpdateAsync(product);

                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(WebImageHandler webImageHandler, int id)
        {
            var dbProduct = await _unitOfWork.Product.GetByIdAsync(id);
            var productOrders = await _unitOfWork.ProductOrder.GetAllAsync(p => p.ProductId == dbProduct.Id);

            if (dbProduct is not null && !productOrders.Any())
            {
                var webRootPath = _hostEnvironment.WebRootPath;

                if (!string.IsNullOrWhiteSpace(dbProduct.Image))
                    webImageHandler.DeleteImage(webRootPath, @"imgs\products\", dbProduct.Image);


                _unitOfWork.Product.Remove(dbProduct);
                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category");
            return Json(new { data = products });
        }
        #endregion
    }
}
