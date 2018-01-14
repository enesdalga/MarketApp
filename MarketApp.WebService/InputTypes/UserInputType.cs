using System;
using GraphQL.Types;

namespace MarketApp.WebService.InputTypes
{
    public class UserInputType: InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInputType";
            Field<NonNullGraphType<IntGraphType>>("UserId");
            Field<NonNullGraphType<StringGraphType>>("FullName");
        }
    }
}