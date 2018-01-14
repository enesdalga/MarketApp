using System;
using System.Collections.Generic;
using System.Linq;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly MarketContext _context;

        public CategoryRepository(MarketContext context)
        {
            _context = context;
        }
        public Category Create(Category category)
        {
            _context.Categories.Add(category);
            var result = _context.SaveChanges();
            return category;
        }

        public Category Delete(int CategoryId)
        {
            var result = 0;
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == CategoryId);
            if (category == null) return category;
            _context.Categories.Remove(category);
            result = _context.SaveChanges();
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(int CategoryId)
        {
            return _context.Categories.Find(CategoryId);
        }

        public Category Update(int CategoryId, Category category)
        {
            var result = 0;
            var oldcategory = GetById(CategoryId);
            if (oldcategory == null) return oldcategory;
            oldcategory.Name = category.Name;
            result = _context.SaveChanges();
            return category;
        }
    }
}
