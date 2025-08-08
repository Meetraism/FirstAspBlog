using CodeYad_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        [Required(ErrorMessage = "نام کاربری را وارد کنید.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد کنید.")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیش از 5 کاراکتر باشد.")]
        public string Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) { return Page(); }
            var result = _userService.LoginUser(new CoreLayer.DTOs.Users.LoginDto()
            {
                UserName = UserName,
                Password = Password
            });
            if (result.Status == CoreLayer.Utilities.OperationResultStatus.NotFound)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات واردشده یافت نشد.");
                return Page();
            }
            return RedirectToPage("../Index");
        }
    }
}
