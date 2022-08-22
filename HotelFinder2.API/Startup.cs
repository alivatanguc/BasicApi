using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Business.MapperProfiles;
using HotelFinder.Business.Models;
using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.DataAccess.Concrete.GenericRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OtelFinder.Entities;
using RabbitMqProduct.RabitMQ;
using StackExchange.Redis;
using static OtelFinder.Entities.Hotel;

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
            //services.AddTransient<IHotelService, HotelManager>();
            //services.AddTransient<ICategoryService, CategoryManager>();
            //services.AddTransient<ICityService, CityManager>();
            //services.AddTransient<ICountryService, CountryManager>();
            //services.AddTransient<ICustomerService, CustomerManager>();
            //services.AddTransient<IRoomService, RoomManager>();

            services.AddDbContext<HotelDbContext>(k => k.UseNpgsql(Configuration.GetConnectionString("HotelConnection")), ServiceLifetime.Scoped);

            services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));


            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient(typeof(IHotelService), typeof(HotelManager));
            services.AddTransient(typeof(ICategoryService), typeof(CategoryManager));
            services.AddTransient(typeof(ICityService), typeof(CityManager));
            services.AddTransient(typeof(ICountryService), typeof(CountryManager));
            services.AddTransient(typeof(ICustomerService), typeof(CustomerManager));
            services.AddTransient(typeof(IRoomService), typeof(RoomManager));
            services.AddTransient(typeof(IHotelRepository), typeof(HotelRepository));
            services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddTransient(typeof(ICityRepository), typeof(CityRepository));
            services.AddTransient(typeof(ICountryRepository), typeof(CountryRepository));
            services.AddTransient(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddTransient(typeof(IRoomRepository), typeof(RoomRepository));
            services.AddTransient(typeof(IReservationRepository), typeof(ReservationRepository));
            services.AddTransient<ISendMessageHotel, SendMessageHotel>();
            services.AddTransient<IRedisCacheService, RedisCacheManager>();
            services.AddScoped<IValidator<HotelModel>, HotelModelValidator>();
            services.AddScoped<IValidator<CategoryModel>, CategoryModelValidator>();
            services.AddScoped<IValidator<CityModel>, CityModelValidator>();
            services.AddScoped<IValidator<CountryModel>, CountryModelValidator>();

            services.AddControllers();
            //services.AddControllers().AddFluentValidation(fv =>
            //{
            //    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            //});
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = $"{Configuration.GetValue<string>("RedisCache:Host")}:{Configuration.GetValue<int>("RedisCache:Port")}";
            });
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("Redis").Value;

            });
            services.AddAutoMapper(typeof(CustomerProfile));

            

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
