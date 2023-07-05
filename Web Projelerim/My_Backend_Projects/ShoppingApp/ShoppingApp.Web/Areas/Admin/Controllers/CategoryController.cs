using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryListDto = new CategoryListDto
            {
                Categories = categories
            };
            ViewBag.SelectedMenu = "Category";
            ViewBag.Title = "Kategoriler";
            return View(categoryListDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = categoryAddDto.Name,
                    Description = categoryAddDto.Description,
                    Url = Jobs.InitUrl(categoryAddDto.Name)
                };
                await _categoryService.CreateAsync(category);
                return RedirectToAction("Index");
                
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category==null)
            {
                return NotFound();
            }
            var categoryUpdateDto = new CategoryUpdateDto
            {
                Id=category.Id,
                Name = category.Name,
                Description = category.Description,
                Url = category.Url
            };
            return View(categoryUpdateDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetByIdAsync(categoryUpdateDto.Id);
                if (category==null)
                {
                    return NotFound();
                }
                category.Name=categoryUpdateDto.Name;
                category.Description=categoryUpdateDto.Description;
                category.Url = Jobs.InitUrl(categoryUpdateDto.Name);

                _categoryService.Update(category);
                return RedirectToAction("Index");

            }
            return View(categoryUpdateDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
