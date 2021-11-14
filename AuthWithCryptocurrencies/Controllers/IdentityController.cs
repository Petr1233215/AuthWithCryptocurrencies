using AuthWithCryptocurrencies.ViewsModels;
using DomainProject;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthWithCryptocurrencies.Controllers
{
    public class IdentityController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IMediator _mediator;

        public IdentityController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
        }

        /// <summary>
        /// Страница регистрации
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Register(ViewRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser { Email = model.Email, UserName = model.Email };
                var identityResult = await _userManager.CreateAsync(appUser, model.Password);

                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(appUser, true);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model); 
        }

        /// <summary>
        /// Страница аутентификации
        /// </summary>
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new ViewLoginModel { ReturnUrl = returnUrl });
        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ViewLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var signResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsRememberMe, false);

                if (signResult.Succeeded)
                {
                    if (model.ReturnUrl != null)
                        return Redirect(model.ReturnUrl);

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                    ModelState.AddModelError(string.Empty, "Email or password not valid");
            }

            return View(model);
        }

        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(IdentityController.Login));
        }
    }
}
