using System;
using GraphQL.Types;

namespace MarketApp.WebService.InputTypes
{
    public class ProductInputType: InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInputType";
            Field<IntGraphType>("ProductId");
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<NonNullGraphType<StringGraphType>>("Description");
            Field<NonNullGraphType<IntGraphType>>("Price");
            Field<NonNullGraphType<StringGraphType>>("ImagePath");
            Field<NonNullGraphType<IntGraphType>>("CategoryId");
        }
    }
}