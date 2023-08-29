using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Queez20.Models;
using Queez20.Repository;

namespace Queez20.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _iCategoryRepository;

        public CategoryController(ICategoryRepository iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _iCategoryRepository.GetAllAsync();
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iCategoryRepository.GetByIdAsync(id);
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {

                await _iCategoryRepository.Create(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _iCategoryRepository.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    category.Id = id;

                    await _iCategoryRepository.Update(category);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _iCategoryRepository.Delete(id);
            return View();
        }


    }
}

