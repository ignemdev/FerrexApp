using Ferrex.Core;
using Ferrex.Core.Models;
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
        public async Task<IActionResult> Upsert(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0) 
                    await _unitOfWork.Product.AddAsync(product);
                else 
                    await _unitOfWork.Product.UpdateAsync(product);

                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStock(Product product)
        {
            if (product.Id != 0) await _unitOfWork.Product.AddStockAsync(product);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.Product.RemoveById(id);
            await _unitOfWork.SaveAsync();
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
