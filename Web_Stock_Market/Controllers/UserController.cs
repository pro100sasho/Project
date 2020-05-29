using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Web_Stock_Market.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = registerUser.Email,
                    UserName = registerUser.Username,
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName
                };

                IdentityResult result = null;
                try
                {
                    result = await _userManager.CreateAsync(user, registerUser.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }                
                catch(DbUpdateException ex)
                {
                    
                    if (ex.InnerException.Message == $"Duplicate entry '{user.Email}' for key 'aspnetusers.Email'")
                    {
                        ModelState.AddModelError("", $"Email {user.Email} is taken");
                    }
                    else
                    {
                        throw ex;
                    }
                    
                }
            }

            return View(registerUser);         
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                User user = await this._userManager.GetUserAsync(User);

                var result = await _signInManager.PasswordSignInAsync(loginUser.Username, loginUser.Password, loginUser.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "Product");
                }
                ModelState.AddModelError("", "Login failed");

            }
            return View(loginUser);
        }

        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Product");
        }

        public async Task<IActionResult> Info(User user)
        {
            user = await _userManager.GetUserAsync(User);
            return View(user);
        }
    }
}