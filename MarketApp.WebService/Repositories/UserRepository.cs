using System;
using System.Collections.Generic;
using System.Linq;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.Repositories
{
    public class UserRepository:IUser
    {
        private readonly MarketContext _context;

        public UserRepository(MarketContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            var result = _context.SaveChanges();
            return user;
        }

        public User Delete(int UserId)
        {
            var result = 0;
            var user = _context.Users.FirstOrDefault(x => x.UserId == UserId);
            if (user == null) return user;
            _context.Users.Remove(user);
            result = _context.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int UserId)
        {
            return _context.Users.Find(UserId);
        }

        public User Update(int UserId, User user)
        {
            var result = 0;
            var olduser = GetById(UserId);
            if (olduser == null) return olduser;
            olduser.FullName = user.FullName;
            result = _context.SaveChanges();
            return user;
        }
    }
}
