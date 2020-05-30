using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web_Stock_Market.Controllers
{
    public class ProductSellController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProductServices productServices;
        private readonly UserManager<User> _userManager;

        public ProductSellController(AppDbContext context, ProductServices productServices, UserManager<User> userManager)
        {
            this._context = context;
            this.productServices = productServices;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Sell(int? id)
        {
            Product product = productServices.GetById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Sell(int? id, int quantity, User user)
        {
            user = await _userManager.GetUserAsync(User);
            int initialQuantity = productServices.GetQuantity(id);
            productServices.Sell(id, quantity);
            int quantityForPrice = initialQuantity - productServices.GetQuantity(id);
            decimal priceToAdd = productServices.GetPrice(id) * quantityForPrice;
            user.Balance += priceToAdd;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index), "Product");           
        }
    }
}