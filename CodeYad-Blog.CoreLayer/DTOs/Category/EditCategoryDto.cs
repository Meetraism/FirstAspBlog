using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.DTOs.Category
{
    public class EditCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
    }
}
