using System;
using GraphQL.Types;
using MarketApp.WebService.Models;
using MarketApp.WebService.ObjectTypes;

namespace MarketApp.WebService.Schemas
{
    public class MarketAppQuery : ObjectGraphType<object>
    {
        public MarketAppQuery(ICategory category, IProduct product,IReview review,IUser user,IOrder order)
        {
            Name = "MarketAppQuery";

            #region Category
            Field<CategoryType>(
                "getCategoryById",
                Description = "This field returns the category of the submitted id",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "CategoryId" }
                ),
                resolve: context => category.GetById(context.GetArgument<int>("CategoryId"))
            );

            Field<ListGraphType<CategoryType>>(
                "getAllCategories",
                Description = "This field returns all categories",
                resolve: context => category.GetAll()
            );
            #endregion

            #region Product
            Field<ProductType>(
                    "getProductById",
                    Description = "This field returns the product of the submitted id",
                    arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "ProductId" }
                    ),
            resolve: context => product.GetById(context.GetArgument<int>("ProductId"))
                );

            Field<ListGraphType<ProductType>>(
                "getAllProducts",
                Description = "This field returns all products",
                resolve: context => product.GetAll()
            );
            #endregion

            #region Review
            Field<ReviewType>(
                    "getReviewById",
                    Description = "This field returns the review of the submitted id",
                    arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "ReviewId"}
                    ),
                resolve: context => review.GetById(context.GetArgument<int>("ReviewId"))
                );

            Field<ListGraphType<ReviewType>>(
                "getAllReviews",
                Description = "This field returns all reviews",
                resolve: context => review.GetAll()
            );
            #endregion

            #region User
            Field<UserType>(
                    "getUserById",
                    Description = "This field returns the user of the submitted id",
                    arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "UserId"}
                    ),
                resolve: context => user.GetById(context.GetArgument<int>("UserId"))
                );

            Field<ListGraphType<UserType>>(
                "getAllUsers",
                Description = "This field returns all users",
                resolve: context => user.GetAll()
            );
            #endregion

            #region Order
            Field<OrderType>(
                    "getOrderById",
                    Description = "This field returns the order of the submitted id",
                    arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "OrderId"}
                    ),
                resolve: context => order.GetById(context.GetArgument<int>("OrderId"))
                );

            Field<ListGraphType<OrderType>>(
                "getAllOrders",
                Description = "This field returns all orders",
                resolve: context => order.GetAll()
            );
            #endregion
            Description = "MarketApp Query Fields for, You can query about categories, products, users, reviews and orders";

        }
    }
}
