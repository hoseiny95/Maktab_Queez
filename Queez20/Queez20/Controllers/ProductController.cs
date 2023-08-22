using Microsoft.AspNetCore.Mvc;
using Queez20.Models;
using Queez20.Repository;

namespace Queez20.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _iproductRepository;

    public ProductController(IProductRepository iproductRepository)
    {
        _iproductRepository = iproductRepository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _iproductRepository.GetAllAsync();
        return View(result);
    }
    public async Task<IActionResult> Details(int id)
    {
        var result = await _iproductRepository.GetByIdAsync(id);
        return View(result);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {

            await _iproductRepository.Create(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _iproductRepository.GetByIdAsync(id);
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (ModelState.IsValid)
        {
            try
            {
                product.Id = id;

                await _iproductRepository.Update(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _iproductRepository.Delete(id);
        return View();
    }


}
