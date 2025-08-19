using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto Map(Category c)
        {
            return new CategoryDto
            {
                // Map to dto
                MetaTag = c.MetaTag,
                MetaDescription = c.MetaDescription,
                Slug = c.Slug,
                ParentId = c.ParentId,
                Id = c.Id,
                Title = c.Title
            };
        }

    }
}
