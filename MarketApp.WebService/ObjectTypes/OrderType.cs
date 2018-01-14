using System;
using GraphQL.Types;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.ObjectTypes
{
    public class OrderType: ObjectGraphType<Order>
    {
        public OrderType(IUser user,IProduct product)
        {
            Name = "Order";
            Description = "Order fields";

            Field(x => x.OrderId).Description("Order Id");
            Field(x => x.Quantity).Description("Product quantity");

            Field<UserType>("User",
                            Description = "the user who places the order",
                                 resolve: context =>
                                 {
                                     return user.GetById(context.Source.UserId);
                                 });
            Field<ProductType>("Product",
                               Description = "Ordered product",
                                 resolve: context =>
                                 {
                                     return product.GetById(context.Source.ProductId);
                                 });
        }
    }
}
