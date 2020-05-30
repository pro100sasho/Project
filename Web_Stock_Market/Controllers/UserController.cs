using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

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
                catch (DbUpdateException ex)
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
                var result = await _signInManager.PasswordSignInAsync(loginUser.Username, loginUser.Password, loginUser.RememberMe, false);

                if (result.Succeeded)
                {
                    
                    return RedirectToAction(nameof(Info), "User");
                }
                ModelState.AddModelError("", "Login failed");

            }

            return View(loginUser);
        }

        public async Task<IActionResult> Logout()
        {
            User user = await _userManager.GetUserAsync(User);
            ProductController.SellerId = null;
            user.LoggedIn = false;
            _userManager.UpdateAsync(user);
            await this._signInManager.SignOutAsync();           
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Info(User user)
        {
            user = await _userManager.GetUserAsync(User);
            ProductController.SellerId = user.Id;
            user.LoggedIn = true;
            _userManager.UpdateAsync(user);
            return View(user);
        }

        [HttpGet]
        public IActionResult DepositIntoAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DepositIntoAccount(User user, decimal amount)
        {
            
            if (amount <= 0)
            {
                ModelState.AddModelError("", "Can not deposit invalid amount of money!");
            }
            else
            {
                user = await _userManager.GetUserAsync(User);
                user.Balance += amount;
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Info), "User");
            }
            return View();
        }
    }
}