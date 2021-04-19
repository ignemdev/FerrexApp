using Ferrex.Core;
using Ferrex.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ferrex.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                    await _unitOfWork.Category.AddAsync(category);
                else
                    await _unitOfWork.Category.UpdateAsync(category);

                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _unitOfWork.Category.RemoveById(id);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _unitOfWork.Category.GetAllAsync();
            return Json(new { data = categories });
        }
        #endregion
    }
}
