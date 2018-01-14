using System;
using System.Collections.Generic;
using System.Linq;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.Repositories
{
    public class ReviewRepository:IReview
    {
        private readonly MarketContext _context;

        public ReviewRepository(MarketContext context)
        {
            _context = context;
        }

        public Review Create(Review review)
        {
            _context.Reviews.Add(review);
            var result = _context.SaveChanges();
            return review;
        }

        public Review Delete(int ReviewId)
        {
            var result = 0;
            var review = _context.Reviews.FirstOrDefault(x => x.ReviewId == ReviewId);
            if (review == null) return review;
            _context.Reviews.Remove(review);
            result = _context.SaveChanges();
            return review;
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review GetById(int ReviewId)
        {
            return _context.Reviews.Find(ReviewId);
        }

        public IEnumerable<Review> GetReviewsByProductId(int ProductId)
        {
            return _context.Reviews.Where(x => x.ProductId == ProductId).ToList();
        }

        public IEnumerable<Review> GetReviewsByUserId(int UserId)
        {
            return _context.Reviews.Where(x => x.UserId == UserId).ToList();
        }

        public Review Update(int ReviewId, Review review)
        {
            var result = 0;
            var oldreview = GetById(ReviewId);
            if (oldreview == null) return oldreview;
            oldreview.Text = review.Text;
            oldreview.Star = review.Star;
            //oldreview.UserId=review.UserId;
            //oldreview.ProductId=review.ProductId;
            result = _context.SaveChanges();
            return review;
        }
    }
}
