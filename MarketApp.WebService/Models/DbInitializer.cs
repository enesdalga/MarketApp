using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace MarketApp.WebService.Models
{
    public class DbInitializer
    {
        public static void Initialize(IApplicationBuilder appBuilder)
        {

            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MarketContext>();

                context.Database.EnsureCreated();

                if (context.Products.Any())
                {
                    return;
                }

                var categories = new List<Category>{
                    new Category(){
                        Name="Computers"
                    },
                    new Category(){
                        Name="Books"
                    }
                };
                foreach (var c in categories)
                {
                    context.Categories.Add(c);
                }
                context.SaveChanges();
                //
                var users = new List<User>{
                    new User(){
                        FullName="Ali Veli"
                    },
                    new User(){
                        FullName="Ahmet Mehmet"
                    }
                };
                foreach (var u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
                //
                var products = new List<Product>{
                    new Product(){
                        Name="Macbook Pro",
                        Description="MBP 15 inch Retina",
                        Price=7000,
                        ImagePath="/images/mbp.jpg",
                        CategoryId=1
                    },
                    new Product(){
                        Name="Refactoring Book",
                        Description="Improving the Design of Existing Code",
                        Price=150,
                        ImagePath="/images/refactoringbook.jpg",
                        CategoryId=2
                    }
                };
                foreach (var p in products)
                {
                    context.Products.Add(p);
                }
                context.SaveChanges();
                //
                var reviews = new List<Review>{
                    new Review(){
                        Text="Great Resource",
                        Star=5,
                        UserId=1,
                        ProductId=2
                    }
                };
                foreach (var r in reviews)
                {
                    context.Reviews.Add(r);
                }
                context.SaveChanges();
                //
                var orders = new List<Order>{
                    new Order(){
                        ProductId=2,
                        UserId=1,
                        Quantity=1
                    }
                };
                foreach (var o in orders)
                {
                    context.Orders.Add(o);
                }
                context.SaveChanges();
            }
        }
    }
}