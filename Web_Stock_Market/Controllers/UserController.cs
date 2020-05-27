using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    Email = registerUser.Email
                };
                IdentityResult result = await this._userManager.CreateAsync(user, registerUser.Password);
            }

            return View(registerUser);
           
        }




        public IActionResult Login()
        {
            return View();
        }
    }
}