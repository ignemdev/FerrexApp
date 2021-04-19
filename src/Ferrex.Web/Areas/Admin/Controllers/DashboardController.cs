using Ferrex.Core;
using Ferrex.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ferrex.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            var dashboardViewModel = new DashboardViewModel();
            var products = await _unitOfWork.Product.GetAllAsync();
            var categories = await _unitOfWork.Category.GetAllAsync();

            dashboardViewModel.RegisteredProducts = products.Count();
            dashboardViewModel.RegisteredCategories = categories.Count();
            dashboardViewModel.WithoutStockProducts = products.Where(p => p.Stock == 0).Count();
            dashboardViewModel.AcumulatedStock = products.Select(p => p.Stock).Sum();
            dashboardViewModel.TodayProducts = products.Where(p => p.CreatedOn.Date == DateTime.Today);
            dashboardViewModel.TodayCategories = categories.Where(p => p.CreatedOn.Date == DateTime.Today);

            return View(dashboardViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
