using Ferrex.Core;
using Ferrex.Core.DTOs;
using Ferrex.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ferrex.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _clientFactory;
        public ProductOrderController(
            IUnitOfWork unitOfWork,
            IHttpClientFactory clientFactory)
        {
            _unitOfWork = unitOfWork;
            _clientFactory = clientFactory;
        }
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {

                productOrder.OrderNumber = Guid.NewGuid().ToString();

                await _unitOfWork.ProductOrder.AddAsync(productOrder);
                await _unitOfWork.SaveAsync();

                var dbProductOrder = await _unitOfWork.ProductOrder
                    .GetFirstOrDefaultAsync(
                    p => p.OrderNumber == productOrder.OrderNumber,
                    includeProperties: "Product"
                    );

                var productOrderDTO = new ProductOrderDTO
                {
                    OrderNumber = dbProductOrder.OrderNumber,
                    ProductName = dbProductOrder.Product.Name,
                    Total = dbProductOrder.Product.Price,
                    RequestedStock = dbProductOrder.RequestedStock,
                    CreatedOn = dbProductOrder.CreatedOn
                };

                var productOrderDTOJson = new StringContent(
                    JsonSerializer.Serialize(productOrderDTO), Encoding.UTF8, "application/json");
                var client = _clientFactory.CreateClient();
                using var httpResponse = await client.PostAsync("https://webapi20210309220319.azurewebsites.net/api/ProductOrders", productOrderDTOJson);
                httpResponse.EnsureSuccessStatusCode();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Enter(int id)
        {
            var dbProductOrder = await _unitOfWork.ProductOrder.GetByIdAsync(id);

            if (dbProductOrder is not null)
            {
                if (dbProductOrder.Accepted && !dbProductOrder.Entered)
                {
                    dbProductOrder.Entered = true;

                    var dbProduct = await _unitOfWork.Product.GetByIdAsync(dbProductOrder.ProductId);
                    dbProduct.Stock += dbProductOrder.RequestedStock;

                    await _unitOfWork.SaveAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productOrders = await _unitOfWork.ProductOrder.GetAllAsync(includeProperties: "Product");
            return Json(new { data = productOrders });
        }

        [HttpPost]
        public async Task<IActionResult> Review([FromBody] ProductOrderDTO productOrderDTO)
        {
            var dbProductOrder = await _unitOfWork.ProductOrder
                .GetFirstOrDefaultAsync(p => p.OrderNumber == productOrderDTO.OrderNumber);

            if (dbProductOrder.Accepted)
                return Json(new { success = false, message = "La orden ya fue aceptada." });

            dbProductOrder.Total = productOrderDTO.Total;
            dbProductOrder.Comment = productOrderDTO.Comment;
            dbProductOrder.Accepted = productOrderDTO.Accepted;
            dbProductOrder.ReviewedOn = DateTime.Now;

            await _unitOfWork.ProductOrder.UpdateAsync(dbProductOrder);
            await _unitOfWork.SaveAsync();

            return Json(new { success = true, message = "Orden revisada exitosamente." });

        }
        #endregion
    }
}
