using CodeYad_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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
            var user = _userService.LoginUser(new CoreLayer.DTOs.Users.LoginDto()
            {
                UserName = UserName,
                Password = Password
            });
            if (user == null)
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات واردشده یافت نشد.");
                return Page();
            }
            List<Claim> claims = new List<Claim>()
            { 
                new Claim("Test", "Test"),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var clientPrincipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(clientPrincipal, properties);
            return RedirectToPage("../Index");
        }
    }
}
