using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using MarketApp.WebService.Models;
using MarketApp.WebService.Repositories;
using MarketApp.WebService.Schemas;
using MarketApp.WebService.InputTypes;
using MarketApp.WebService.ObjectTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MarketApp.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFrameworkNpgsql().AddDbContext<MarketContext>(opt =>
              opt.UseNpgsql(Configuration.GetConnectionString("Baglanti")));

            services.AddSingleton<ICategory, CategoryRepository>();
            services.AddSingleton<IProduct, ProductRepository>();
            services.AddSingleton<IReview, ReviewRepository>();
            services.AddSingleton<IUser, UserRepository>();
            services.AddSingleton<IOrder, OrderRepository>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<CategoryType>();
            services.AddSingleton<ProductType>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<ReviewType>();

            services.AddSingleton<CategoryInputType>();
            services.AddSingleton<UserInputType>();
            services.AddSingleton<ReviewInputType>();
            services.AddSingleton<ProductInputType>();
            services.AddSingleton<OrderInputType>();

            services.AddScoped<MarketAppQuery>();
            services.AddScoped<MarketAppMutation>();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new MarketAppSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<MarketAppQuery>() });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            DbInitializer.Initialize(app);
        }
    }
}
