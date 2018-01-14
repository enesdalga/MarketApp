using System;
using System.Collections.Generic;

namespace MarketApp.WebService.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        List<Review> Reviews { get; set; }
        List<Order> Orders { get; set; }
    }
}
