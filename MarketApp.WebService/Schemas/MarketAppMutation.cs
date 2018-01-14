using System;
using GraphQL.Types;
using MarketApp.WebService.Models;
using MarketApp.WebService.ObjectTypes;
using MarketApp.WebService.InputTypes;

namespace MarketApp.WebService.Schemas
{
    public class MarketAppMutation : ObjectGraphType<object>
    {
        public MarketAppMutation(ICategory category, IUser user, IReview review, IProduct product,IOrder order)
        {
            Name = "MarketAppMutation";

            #region Category
            Field<CategoryType>(
                "AddCategory",
                Description = "This field adds new category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "CategoryName" }
                ),
                resolve: context =>
                {
                    var categoryName = context.GetArgument<string>(Name = "CategoryName");
                    return category.Create(new Category()
                    {
                        Name = categoryName
                    });
                });

            Field<CategoryType>(
               "deleteCategory",
                Description = "This field delete category by CategoryId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "CategoryId" }
               ),
               resolve: context =>
               {
                   var categoryId = context.GetArgument<int>("CategoryId");
                   return category.Delete(categoryId);
               });

            Field<CategoryType>(
               "updateCategory",
                Description = "This field update category by CategoryId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "Category" }
               ),
               resolve: context =>
               {
                   var categoryInput = context.GetArgument<Category>("Category");
                   return category.Update(categoryInput.CategoryId, categoryInput);
               });

            #endregion

            #region User
            Field<UserType>(
                "addUser",
                Description = "This field adds new user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "UserName" }
                ),
                resolve: context =>
                {
                    var userName = context.GetArgument<string>(Name = "UserName");
                    return user.Create(new User()
                    {
                        FullName = userName
                    });
                });

            Field<UserType>(
               "deleteUser",
                Description = "This field delete user by UserId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "UserId" }
               ),
               resolve: context =>
               {
                   var userId = context.GetArgument<int>("UserId");
                   return user.Delete(userId);
               });

            Field<UserType>(
                "updateUser",
                Description = "This field update user by UserId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "User" }
               ),
               resolve: context =>
               {
                   var userInput = context.GetArgument<User>("User");
                   return user.Update(userInput.UserId, userInput);
               });

            #endregion

            #region Review
            Field<ReviewType>(
                "addReview",
                Description = "This field adds new review",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>> { Name = "Review" }
                ),
                resolve: context =>
                {
                    var reviewInput = context.GetArgument<Review>(Name = "Review");
                    return review.Create(reviewInput);
                });

            Field<ReviewType>(
                "deleteReview",
                Description = "This field delete review by ReviewId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "ReviewId" }
               ),
               resolve: context =>
               {
                   var reviewId = context.GetArgument<int>("ReviewId");
                   return review.Delete(reviewId);
               });

            Field<ReviewType>(
                "updateReview",
                Description = "This field update Review by ReviewId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "ReviewId" },
                    new QueryArgument<NonNullGraphType<ReviewInputType>> { Name = "Review" }
               ),
               resolve: context =>
               {
                   var reviewId = context.GetArgument<int>("ReviewId");
                   var reviewInput = context.GetArgument<Review>("Review");
                   return review.Update(reviewId, reviewInput);
               });

            #endregion

            #region Product
            Field<ProductType>(
                "addProduct",
                Description = "This field adds new product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "Product" }
                ),
                resolve: context =>
                {
                    var productInput = context.GetArgument<Product>(Name = "Product");
                    return product.Create(productInput);
                });

            Field<ProductType>(
                "deleteProduct",
                Description = "This field delete product by ProductId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "ProductId" }
               ),
               resolve: context =>
               {
                   var productId = context.GetArgument<int>("ProductId");
                   return product.Delete(productId);
               });

            Field<ProductType>(
                "updateProduct",
                Description = "This field update Product by ProductId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "ProductId" },
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "Product" }
               ),
               resolve: context =>
               {
                var productId = context.GetArgument<int>("ProductId");
                   var productInput = context.GetArgument<Product>("Product");
                   return product.Update(productId, productInput);
               });
            #endregion

            #region Order
            Field<OrderType>(
                "addOrder",
                Description = "This field adds new order",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "Order" }
                ),
                resolve: context =>
                {
                var orderInput = context.GetArgument<Order>(Name = "Order");
                    return order.Create(orderInput);
                });

            Field<OrderType>(
                "deleteOrder",
                Description = "This field delete order by OrderId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "OrderId" }
               ),
               resolve: context =>
               {
                var orderId = context.GetArgument<int>("OrderId");
                return order.Delete(orderId);
               });

            Field<OrderType>(
                "updateOrder",
                Description = "This field update Order by OrderId",
               arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "OrderId" },
                    new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "Order" }
               ),
               resolve: context =>
               {
                var orderId = context.GetArgument<int>("OrderId");
                var orderInput = context.GetArgument<Order>("Order");
                return order.Update(orderId, orderInput);
               });
            #endregion

            Description = "MarketApp Mutation Fields for, You can add, delete, update about categories, products, users, reviews and orders";
        }
    }
}
