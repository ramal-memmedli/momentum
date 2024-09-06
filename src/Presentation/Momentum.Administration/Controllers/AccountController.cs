using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Momentum.Application.ViewModels.Account;
using Momentum.Domain.Entities;

namespace Momentum.Administration.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser newUser = new AppUser()
            {
                UserName = registerVM.Username,
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                Email = registerVM.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (!result.Succeeded) {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                    return View(registerVM);
                }
            }

            return RedirectToAction(controllerName: nameof(AccountController), actionName: "Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                RedirectToAction(controllerName: nameof(DashboardController), actionName: "Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser? user = await _userManager.FindByNameAsync(loginVM.Username);

            if (user is null)
            {
                ModelState.AddModelError("", "Login failed. Please check your credentials and try again.");
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersistent, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account locked out, please try again later");
                return View();
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View();
            }

            return RedirectToAction(controllerName: nameof(DashboardController), actionName: "Index");
        }
    }
}
