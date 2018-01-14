using System;
using System.Collections.Generic;
using System.Linq;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly MarketContext _context;

        public OrderRepository(MarketContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            _context.Orders.Add(order);
            var result = _context.SaveChanges();
            return order;
        }

        public Order Delete(int OrderId)
        {
            var result = 0;
            var order = _context.Orders.FirstOrDefault(x => x.OrderId == OrderId);
            if (order == null) return order;
            _context.Orders.Remove(order);
            result = _context.SaveChanges();
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int OrderId)
        {
            return _context.Orders.Find(OrderId);
        }

        public IEnumerable<Order> GetOrdersByProductId(int ProductId)
        {
            return _context.Orders.Where(x => x.ProductId == ProductId).ToList();
        }

        public IEnumerable<Order> GetOrdersByUserId(int UserId)
        {
            return _context.Orders.Where(x => x.UserId == UserId).ToList();
        }

        public Order Update(int OrderId, Order order)
        {
            var result = 0;
            var oldorder = GetById(OrderId);
            if (oldorder == null) return oldorder;
            oldorder.Quantity = order.Quantity;
            result = _context.SaveChanges();
            return order;
        }
    }
}
