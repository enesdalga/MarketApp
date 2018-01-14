using System;
using System.Collections.Generic;
using System.Linq;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.Repositories
{
    public class ProductRepository:IProduct
    {
        private readonly MarketContext _context;

        public ProductRepository(MarketContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            var result = _context.SaveChanges();
            return product;
        }

        public Product Delete(int ProductId)
        {
            var result = 0;
            var product = _context.Products.FirstOrDefault(x => x.ProductId == ProductId);
            if (product == null) return product;
            _context.Products.Remove(product);
            result = _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int CategoryId)
        {
            return _context.Products.Where(x => x.CategoryId == CategoryId).ToList();
        }

        public Product GetById(int ProductId)
        {
            return _context.Products.Find(ProductId);
        }

        public Product Update(int ProductId, Product product)
        {
            var result = 0;
            var oldproduct = GetById(ProductId);
            if (oldproduct == null) return oldproduct;
            oldproduct.Name = product.Name;
            oldproduct.Description = product.Description;
            oldproduct.Price = product.Price;
            oldproduct.ImagePath = product.ImagePath;
            oldproduct.CategoryId = product.CategoryId;
            result = _context.SaveChanges();
            return product;
        }
    }
}
