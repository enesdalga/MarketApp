using System;
using GraphQL.Types;

namespace MarketApp.WebService.Schemas
{
    public class MarketAppSchema:Schema
    {
        public MarketAppSchema(Func<Type, GraphType> resolve) : base(resolve)
        {
            Query = (MarketAppQuery)resolve(typeof(MarketAppQuery));
            Mutation = (MarketAppMutation)resolve(typeof(MarketAppMutation));
        }
    }
}
