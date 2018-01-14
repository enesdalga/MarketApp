using System;
namespace MarketApp.WebService.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Text { get; set; }
        public int Star { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
