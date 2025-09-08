using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Mappers;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto command)
        {
            if (IsSlugExist(command.Slug))
                return OperationResult.Error("Slug Is Exist");
            var category = new Category()
            {
                Title = command.Title,
                IsDelete = false,
                ParentId = command.ParentId,
                Slug = command.Slug.ToSlug(),
                MetaTag = command.MetaTag,
                MetaDescription = command.MetaDescription
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

   
        public OperationResult EditCategory(EditCategoryDto command)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == command.Id);
            //var category = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == command.Id);
            if (category==null)
                return OperationResult.NotFound();

            if (command.Slug.ToSlug() != category.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("Slug Is Exist");

            category.Title = command.Title;
            category.MetaDescription = command.MetaDescription;
            category.MetaTag = command.MetaTag;
            category.Slug = command.Slug.ToSlug();
            _context.Update(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _context.Categories.Select(c => CategoryMapper.Map(c)).ToList(); 
        }

        public CategoryDto GetCategoryBy(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return null;

            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public bool IsSlugExist(string slug)
        {
            return _context.Categories.Any(c => c.Slug == slug.ToSlug());
        }
    }
}
