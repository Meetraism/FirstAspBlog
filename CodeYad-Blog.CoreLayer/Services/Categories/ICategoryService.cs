using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto command);
        OperationResult EditCategory(EditCategoryDto command);
        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);
        bool IsSlugExist(string slug);
    }
}
