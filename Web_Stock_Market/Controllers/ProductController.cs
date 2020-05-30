using Business;
using Data;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Web_Stock_Market.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProductServices productServices;
        private readonly UserManager<User> _userManager;

        public ProductController(AppDbContext context, ProductServices productServices, UserManager<User> userManager)
        {
            this._context = context;
            this.productServices = productServices;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Product> products = productServices.GetAll();
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            Product product = productServices.GetById(id);

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                productServices.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        public IActionResult Edit(int? id)
        {
            Product product = productServices.GetById(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ProductDto product)
        {
            if (ModelState.IsValid)
            {
                productServices.Edit(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {            
            Product product = productServices.GetById(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            productServices.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }       
    }
}
