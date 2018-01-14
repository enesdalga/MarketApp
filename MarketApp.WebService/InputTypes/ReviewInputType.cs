using System;
using GraphQL.Types;

namespace MarketApp.WebService.InputTypes
{
    public class ReviewInputType: InputObjectGraphType
    {
        public ReviewInputType()
        {
            Name = "ReviewInputType";
            Field<IntGraphType>("ReviewId");
            Field<NonNullGraphType<StringGraphType>>("Text");
            Field<NonNullGraphType<IntGraphType>>("Star");
            Field<NonNullGraphType<IntGraphType>>("UserId");
            Field<NonNullGraphType<IntGraphType>>("ProductId");

        }
    }
}