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
        void EditCategory(CreateCategoryDto createCategoryDto);
    }
}
