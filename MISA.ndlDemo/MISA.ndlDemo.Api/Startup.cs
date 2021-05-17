using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NDL.DL;
using NDL.SV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ndlDemo.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("allowOrigins",
                                builder =>
                                {
                                    builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.ndlDemo.Api", Version = "v1" });
            });
            services.AddScoped(typeof(IBaseSV<>),typeof(BaseSV<>));
            services.AddScoped(typeof(ICustomerSV), typeof(CustomerSV));
            services.AddScoped(typeof(ICustomerGroupSV), typeof(CustomerGroupSV));
            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDl<>));
            services.AddScoped(typeof(ICustomerDL), typeof(CustomerDL));
            services.AddScoped(typeof(ICustomerGroupDL), typeof(CustomerGroupDL));
            services.AddScoped(typeof(IEmployeeDL), typeof(EmployeeDL));
            services.AddScoped(typeof(IEmployeeSV), typeof(EmployeeSV));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.ndlDemo.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("allowOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
