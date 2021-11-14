using AuthWithCryptocurrencies.ViewsModels;
using DomainProject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthWithCryptocurrencies.Controllers
{
    public class IdentityController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public IdentityController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new ViewLoginModel { ReturnUrl = returnUrl });
        }

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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(IdentityController.Login));
        }
    }
}
