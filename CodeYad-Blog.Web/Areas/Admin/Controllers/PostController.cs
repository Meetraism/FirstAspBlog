using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace CodeYad_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index(int pageId=1, string title="", string categorySlug="")
        {
            var param = new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageId = pageId,
                Title = title,
                Take = 20,
            };
            var model = _postService.GetPostByFilter(param);
            return View(model);
        }
    }
}
