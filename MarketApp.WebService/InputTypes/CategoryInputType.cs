using System;
using GraphQL.Types;

namespace MarketApp.WebService.InputTypes
{
    public class CategoryInputType: InputObjectGraphType
    {
        public CategoryInputType()
        {
            Name = "CategoryInputType";
            Field<NonNullGraphType<IntGraphType>>("CategoryId");
            Field<NonNullGraphType<StringGraphType>>("Name");
        }
    }
}