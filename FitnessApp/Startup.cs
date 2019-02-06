using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Context;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using FitnessApp.Configuration;
using FitnessApp.Services.Implementations;
using FitnessApp.Services.Implementations.Calculators;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace FitnessApp
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
            var st = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<WebApiContext>(
                options => options.UseMySql(st,
                mysqlOptions =>
                {
                    mysqlOptions.ServerVersion(new Version(5, 5, 0), ServerType.MySql); // replace with your Server Version and Type
                }
            ));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = "http://localhost:5000",
                            ValidAudience = "http://localhost:5000",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeySuper@345"))
                        };
                    });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            services.AddCors(options => options.AddPolicy("MyPolicy", p => p.AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                             .AllowAnyHeader()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //-----REPOSITORIES-----
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INewsletterRepository, NewsletterRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();


            //-----SERVICES-----
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICalculatorFactory, CalculatorFactory>();
            services.AddTransient<INewsletterService, NewsletterService>();
            services.AddTransient<ITimeProvider, DateTimeProvider>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            //loggerFactory.AddLog4Net();
        }
    }
}
