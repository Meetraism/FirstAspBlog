using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeYad_Blog.Web.Pages
{
    public class CustomModel : PageModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void OnGet()
        {
            Name = "Mitra";
            Age = 20;
        }
        public IActionResult OnPost()
        {
            return Redirect("/");
        }
    }
}
