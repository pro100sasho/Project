using Data;
using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class ProductServices
    {
        public readonly AppDbContext _context;

        public ProductServices(AppDbContext context)
        {
            this._context = context;
        }

        public List<Product> GetAll()
        {
            return new List<Product>(_context.Products);
        }

        public Product GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }

            Product product = _context.Products
                .FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                //throw new ProductNotFoundException("A product was not found");
                throw new ArgumentNullException("Id must not be null");
            }
            return product;
        }

        public void Create(ProductDto product)
        {
            _context.Products.Add(this.OfProductDto(product));
            _context.SaveChanges();
        }

        public Product Edit(int? id, ProductDto newProduct)
        {
            Product returnProduct = null;
            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }

            try
            {
                returnProduct = _context.Update(this.OfProductDto(newProduct)).Entity;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Product product = _context.Products
                    .FirstOrDefault(u => u.Id == id);

                if (product == null)
                {
                    //throw new ProductNotFoundException("A Product was not found");
                    throw new ArgumentNullException("Id must not be null");
                }
                else
                {
                    throw new Exception("Product can not be updated");
                }
            }
            return returnProduct;
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id must not be null");
            }

            Product product = _context.Products
                .FirstOrDefault(m => m.Id == id);
                       
            _context.Products.Remove(product);
            _context.SaveChanges();
        }



        private Product OfProductDto(ProductDto productDto)
        {
            return new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };
        }
    }

}
