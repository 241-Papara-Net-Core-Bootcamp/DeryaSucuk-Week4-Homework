using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using PaparaThirdWeek.Data.Dapper;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PaparaThirdWeek.Data.Abstracts;
using PaparaThirdWeek.Data.Concretes;
using PaparaThirdWeek.Data.Context;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.Concretes;
using PaparaThirdWeek.Services.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaparaThirdWeek.Api", Version = "v1" });
            });
            services.AddDbContext<PaparaAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient(typeof(IGenericRepository<>), typeof(CompanyRepository<>));

            services.AddTransient<ICompanyService, CompanyServices>();
            services.AddAutoMapper(typeof(MappingProfile));
            
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());//profilfden miras aldýðýmýz tüm classlarý tarayýp recuster ediyor.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaparaThirdWeek.Api v1"));
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
