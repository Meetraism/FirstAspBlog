using CodeYad_Blog.CoreLayer.DTOs.Category;
using CodeYad_Blog.DataLayer.Context;
using System;
using System.Linq;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        public readonly BlogContext _context;
        public CategoryService(BlogContext context)
        {  _context = context; }
        public void CreateCategory(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(EditCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAllCategory(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
