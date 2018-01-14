using System;
using System.Collections.Generic;

namespace MarketApp.WebService.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        List<Review> Reviews { get; set; }
        List<Order> Orders { get; set; }
    }
}
