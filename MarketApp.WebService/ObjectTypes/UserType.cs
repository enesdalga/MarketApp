using System;
using GraphQL.Types;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.ObjectTypes
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(IReview review,IOrder order)
        {
            Name = "User";
            Description = "User fields";

            Field(x => x.UserId).Description("User Id");
            Field(x => x.FullName).Description("User name and surname");

            Field<ListGraphType<ReviewType>>("Reviews",
                                             Description = "User reviews",
                                  resolve: context =>
                                  {
                                      return review.GetReviewsByUserId(context.Source.UserId);
                                  });
            Field<ListGraphType<OrderType>>("Orders",
                                             Description = "User orders",
                                  resolve: context =>
                                  {
                                      return review.GetReviewsByUserId(context.Source.UserId);
                                  });
        }
    }
}
