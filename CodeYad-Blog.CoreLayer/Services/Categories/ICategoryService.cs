using CodeYad_Blog.CoreLayer.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        void CreateCategory(CreateCategoryDto createCategoryDto);
        void EditCategory(EditCategoryDto createCategoryDto);
        List<CategoryDto> GetAllCategory(int id);
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);

    }
}
