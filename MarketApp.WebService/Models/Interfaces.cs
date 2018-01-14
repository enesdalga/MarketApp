using System;
using System.Collections.Generic;

namespace MarketApp.WebService.Models
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category GetById(int CategoryId);
        Category Create(Category category);
        Category Update(int CategoryId, Category category);
        Category Delete(int CategoryId);
    }
    public interface IUser
    {
        IEnumerable<User> GetAll();
        User GetById(int UserId);
        User Create(User user);
        User Update(int UserId, User user);
        User Delete(int UserId);
    } 
    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product GetById(int ProductId);
        IEnumerable<Product> GetProductsByCategoryId(int CategoryId);
        Product Create(Product product);
        Product Update(int ProductId, Product product);
        Product Delete(int ProductId);
    }
    public interface IReview
    {
        IEnumerable<Review> GetAll();
        Review GetById(int ReviewId);
        IEnumerable<Review> GetReviewsByProductId(int ProductId);
        IEnumerable<Review> GetReviewsByUserId(int UserId);
        Review Create(Review review);
        Review Update(int ReviewId, Review review);
        Review Delete(int ReviewId);
    }    
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        Order GetById(int OrderId);
        IEnumerable<Order> GetOrdersByProductId(int ProductId);
        IEnumerable<Order> GetOrdersByUserId(int UserId);
        Order Create(Order order);
        Order Update(int OrderId, Order order);
        Order Delete(int OrderId);
    }
}
