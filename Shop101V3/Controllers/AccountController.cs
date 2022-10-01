using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop101V3.Models;
using Shop101V3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser newUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                Age = registerViewModel.Age,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email.Split("@")[0]
            };

            IdentityResult result = await userManager.CreateAsync(newUser, registerViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerViewModel);
            }

            await signInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
