using System;
using GraphQL.Types;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.ObjectTypes
{
    public class ProductType:ObjectGraphType<Product>
    {
        public ProductType(ICategory category,IReview review,IOrder order)
        {
            Name = "Product";
            Description = "Product fields";

            Field(x => x.ProductId).Description("Product Id");
            Field(x => x.Name).Description("Product name");
            Field(x => x.Description).Description("Product description");
            Field(x => x.Price).Description("Product price");
            Field(x => x.ImagePath).Description("Product image path");

            Field<ProductType>("Category",
                               Description="Category of product",
                                  resolve: context =>
                                  {
                return category.GetById(context.Source.CategoryId);
                                  });
            Field<ListGraphType<ReviewType>>("Reviews",
                               Description = "Reviews of product",
                                  resolve: context =>
                                  {
                                      return review.GetReviewsByProductId(context.Source.ProductId);
                                  });
            Field<ListGraphType<OrderType>>("Orders",
                               Description = "Orders of product",
                                  resolve: context =>
                                  {
                                      return order.GetOrdersByProductId(context.Source.ProductId);
                                  });
        }
    }
}
