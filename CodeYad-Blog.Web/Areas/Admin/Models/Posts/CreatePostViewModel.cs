using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Areas.Admin.Models.Posts
{
    public class CreatePostViewModel
    {
        [Display(Name = "انتخاب دسته بندی")]
        [Required(ErrorMessage = "enter {0}")]
        public int CategoryId { get; set; }

        [Display(Name = "انتخاب دسته بندی")]
        [Required(ErrorMessage = "enter {0}")]
        public int? SubCategoryId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "enter {0}")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "enter {0}")]
        [UIHint("CkEditor4")]
        public string Description { get; set; }

        [Display(Name = "slug")]
        [Required(ErrorMessage = "enter {0}")]
        public string Slug { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "enter {0}")]
        public IFormFile ImageFile;
    }
}
