using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMqProduct.RabitMQ;
using StackExchange.Redis;

namespace HotelFinder2.API
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            
           var redis = ConnectionMultiplexer.Connect("localhost");
            services.AddScoped(s=>redis.GetDatabase());
            services.AddScoped<IHotelService, HotelManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<IRabbitMQHotel, RabitMQHotel>();



            services.AddControllers();
          
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("Redis").Value;

            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                   );
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Hotel API",
                    Version = "v1",
                    Description = "Sample service for Learner",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaceInfo Services"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
