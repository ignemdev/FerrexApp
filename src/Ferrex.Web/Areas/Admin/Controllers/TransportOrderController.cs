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
    public class TransportOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _clientFactory;

        public TransportOrderController(
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
        public async Task<IActionResult> Create(TransportOrder transportOrder)
        {
            if (ModelState.IsValid)
            {
                transportOrder.OrderNumber = Guid.NewGuid().ToString();

                await _unitOfWork.TransportOrder.AddAsync(transportOrder);
                await _unitOfWork.SaveAsync();

                var dbTransportOrder = await _unitOfWork.TransportOrder
                    .GetFirstOrDefaultAsync(
                    p => p.OrderNumber == transportOrder.OrderNumber);

                var transportOrderDTO = new TransportOrderDTO
                {
                    OrderNumber = dbTransportOrder.OrderNumber,
                    RequestedDay = dbTransportOrder.RequestedDay,
                    RequestedKilometers = dbTransportOrder.RequestedKilometers,
                    CreatedOn = dbTransportOrder.CreatedOn
                };
                
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var transportOrderDTOJson = new StringContent(
                  JsonSerializer.Serialize(transportOrderDTO, serializeOptions), Encoding.UTF8, "application/json");
                var client = _clientFactory.CreateClient();
                using var httpResponse = await client.PostAsync("https://kamionapp.herokuapp.com/api/orders", transportOrderDTOJson);
                httpResponse.EnsureSuccessStatusCode();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Date.");
                return View();
            }


            return RedirectToAction(nameof(Index));
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transportOrders = await _unitOfWork.TransportOrder.GetAllAsync();
            return Json(new { data = transportOrders });
        }

        [HttpPost]
        public async Task<IActionResult> Review([FromBody] TransportOrderDTO transportOrderDTO)
        {
            var dbTransportOrder = await _unitOfWork.TransportOrder
                .GetFirstOrDefaultAsync(p => p.OrderNumber == transportOrderDTO.OrderNumber);

            if (dbTransportOrder.Accepted)
                return Json(new { success = false, message = "La orden ya fue aceptada." });

            dbTransportOrder.TruckDescription = transportOrderDTO.TruckDescription;
            dbTransportOrder.Total = transportOrderDTO.Total;
            dbTransportOrder.Comment = transportOrderDTO.Comment;
            dbTransportOrder.Accepted = transportOrderDTO.Accepted;
            dbTransportOrder.ReviewedOn = DateTime.Now;

            await _unitOfWork.TransportOrder.UpdateAsync(dbTransportOrder);
            await _unitOfWork.SaveAsync();

            return Json(new { success = true, message = "Orden revisada exitosamente." });

        }
        #endregion
    }
}
