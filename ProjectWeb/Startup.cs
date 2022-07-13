using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BL;

namespace ProjectWeb
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //הוספת קישור למסד
            services.AddDbContext<DataProject>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin-c\Desktop\Project_shiraSaraMalul\DateProject1.mdf;Integrated Security=True;Connect Timeout=30 "), ServiceLifetime.Scoped);
            //הוספת ממיר
            services.AddAutoMapper(typeof(Startup));
            //הוספת סרוויס מוצרים
            services.AddScoped<IProductDAL, ProductsDAL>();
            services.AddScoped<IProductBL, ProductBL>();
            //הוספת סרוויס מלקטים
            services.AddScoped<ICollectorDAL,CollectorDAL>();
            services.AddScoped<ICollectorBL, CollectorBL>();
            //הוספת סרוויס צבעים
            services.AddScoped<IColorDAL, ColorsDAL>();
            services.AddScoped<IColorsBL, ColorsBL>();
            //הוספת סרוויס מחסנים
            services.AddScoped<IStorageDAL, StorageDAL>();
            services.AddScoped<IStorageBL, StorageBL>();
            //הוספת סרוויס קבוצת מוצרים
            services.AddScoped<IProductGroupsDAL, ProductGroupsDAL>();
            services.AddScoped<IProductGroupsBL, ProductGroupsBL>();
            //הוספת סרוויס דגם מוצר
            services.AddScoped<IProductModelsDAL, ProductModelsDAL>();
            services.AddScoped<IProductModelsBL, ProductModelsBL>();
            //הוספת סרוויס מוצרים בהזמנה
            services.AddScoped<IProductsOnOrderDAL, ProductsOnOrderDAL>();
            services.AddScoped<IProductsOnOrderBL, ProductsOnOrderBL>();
            //הוספת סרוויס הזמנות
            services.AddScoped<IOrdersDAL, OrdersDAL>();
            services.AddScoped<IOrdersBL, OrdersBL>();
            //הוספת סרוויס של האלגוריתם
            services.AddScoped<Igrafh, Graph>();


            //חיבור לאנגולר

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                    builder.WithHeaders("Content-Type");
                    builder.WithMethods(new String[] { "GET", "POST", "PUT", "DELETE" }); ;
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddControllers();
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

          
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                RequestPath = new PathString("/wwwroot")
            });
        }
    }
}
