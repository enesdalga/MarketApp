using System;
using GraphQL.Types;

namespace MarketApp.WebService.InputTypes
{
    public class OrderInputType: InputObjectGraphType
    {
        public OrderInputType()
        {
            Name = "OrderInputType";
            Field<IntGraphType>("OrderId");
            Field<NonNullGraphType<IntGraphType>>("Quantity");
            Field<NonNullGraphType<IntGraphType>>("ProductId");
            Field<NonNullGraphType<IntGraphType>>("UserId");
        }
    }
}