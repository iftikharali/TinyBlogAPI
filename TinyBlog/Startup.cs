using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TinyBlog.Repositories;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Middlewares;
using Microsoft.AspNetCore.Authentication;
using TinyBlog.Handlers;
using TinyBlog.Services.Interfaces;
using TinyBlog.Services;

namespace TinyBlog
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
            services.AddCors();
            services.AddControllers();
            //services.AddRazorPages();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Tiny Blog API",
                        Description = "A simple and easy blog which anyone love to blog"
                    });
            });
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            //    {
            //        Version = "v1",
            //        Title = "Tiny Blog API",
            //        Description = "A simple and easy blog which anyone love to blog."
            //    });
            //});
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();
            services.AddSingleton<IBlogRepository, BlogRepository>();

            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )//IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //app.UseStaticFiles();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tiny Blog V1");
            });

            app.UseEndpoints(endpoint => { endpoint.MapControllers(); });
            //app.UseMvc();
        }
    }
}
