using CodeYad_Blog.CoreLayer.Services.Categories;
using CodeYad_Blog.CoreLayer.Utilities;
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
        public IActionResult Add(CreateCategoryViewModel vm) 
        {
            var result = _categoryService.CreateCategory(vm.MapToDto());
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(vm.Slug), result.Message);
                return View();
            }
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
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel vm)
        {
            var result = _categoryService.EditCategory(new CoreLayer.DTOs.Categories.EditCategoryDto()
            {
                Slug = vm.Slug,
                MetaTag = vm.MetaTag,
                MetaDescription = vm.MetaDescription,
                Title = vm.Title,
                Id = id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(vm.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
