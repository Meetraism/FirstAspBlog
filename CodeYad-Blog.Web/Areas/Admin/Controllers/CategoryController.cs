using CodeYad_Blog.CoreLayer.Services.Categories;
using CodeYad_Blog.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateCategoryViewModel createViewModel) 
        {
            var result = _categoryService.CreateCategory(createViewModel.MapToDto());
            return RedirectToAction("Index");
        }
    }
}
