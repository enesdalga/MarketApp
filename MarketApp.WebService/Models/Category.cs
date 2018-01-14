using System;
using System.Collections.Generic;

namespace MarketApp.WebService.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        List<Product> Products { get; set; }
    }
}
