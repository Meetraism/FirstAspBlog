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
        public IActionResult Edit(int id) 
        { 
            var category = _categoryService.GetCategoryBy(id);
            if (category == null)
                return RedirectToAction("Index");
            var model = new EditCategoryViewModel()
            {
                Slug = category.Slug,
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
                Title = category.Title
            };
            return View(model);
        }
    }
}
