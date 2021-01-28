using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using ODataSample.Services;
using Microsoft.AspNet.OData.Builder;
using ODataSample.Models;


namespace ODataSample
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
            services.AddTransient<IUsersService, UsersService>();

            /*
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
            });*/

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            //services.AddControllers().AddNewtonsoftJson();

            services.AddOData();
        }

        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);
            builder.EntitySet<User>("search");
            //builder.Function("Users.Search");

            return builder.GetEdmModel();
        }

        public IEdmModel GetEdmModelForUsers()
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EntitySet<User>("search");

            return edmBuilder.GetEdmModel();
        }

        public IEdmModel GetEdmModelForPersons()
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EntitySet<User>("users");

            return edmBuilder.GetEdmModel();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseMvc(configureRoutes =>
            {
                configureRoutes.EnableDependencyInjection();
                configureRoutes.Expand().Select().OrderBy().Filter().MaxTop(5).Count();
                configureRoutes.MapODataServiceRoute("odata", "odata", GetEdmModelForPersons());
            });

        }
    }
}
