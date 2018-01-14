using System;
using GraphQL.Types;
using MarketApp.WebService.Models;

namespace MarketApp.WebService.ObjectTypes
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProduct product)
        {
            Name = "Category";
            Description = "Product Category";

            Field(x => x.CategoryId).Description("Category Id");
            Field(x => x.Name).Description("Category name");

            Field<ListGraphType<ProductType>>("Products",
                                              Description = "Products in this category",
                                  resolve: context =>
                                  {
                                      return product.GetProductsByCategoryId(context.Source.CategoryId);
                                  });
        }
    }
}
