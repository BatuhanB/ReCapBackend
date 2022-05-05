using Businness.Abstract;
using Businness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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

            services.AddControllers();
            services.AddSingleton<ICarService, CarManager>();//Car controller injection chains
            services.AddSingleton<ICarDal, EfCarDal>();
            services.AddSingleton<IBrandService, BrandManager>();//Brand controller injection chains
            services.AddSingleton<IBrandDal, EfBrandDal>();
            services.AddSingleton<IColorService, ColorManager>();//Color controller injection chains
            services.AddSingleton<IColorDal, EfColorDal>();
            services.AddSingleton<ICustomerService, CustomerManager>();//Customer controller injection chains
            services.AddSingleton<ICustomerDal, EfCustomerDal>();
            services.AddSingleton<IRentalService, RentalManager>();//Rental controller injection chains
            services.AddSingleton<IRentalDal, EfRentalDal>();
            services.AddSingleton<IUserService, UserManager>();//User controller injection chains
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
