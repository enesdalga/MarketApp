using System;
using GraphQL.Types;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.ObjectTypes
{
    public class ReviewType: ObjectGraphType<Review>
    {
        public ReviewType(IUser user,IProduct product)
        {
            Name = "Review";
            Description = "Review fields";

            Field(x => x.ReviewId).Description("Review Id");
            Field(x => x.Text).Description("Review text");
            Field(x => x.Star).Description("Review star");

            Field<UserType>("User",
                               Description = "User's review",
                                  resolve: context =>
                                  {
                                      return user.GetById(context.Source.UserId);
                                  });
            Field<ProductType>("Product",
                               Description = "Reviewed product",
                                 resolve: context =>
                                 {
                                     return product.GetById(context.Source.ProductId);
                                 });
        }
    }
}
