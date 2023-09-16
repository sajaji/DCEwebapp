using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DCEwebapp.Data;
using DCEwebapp.DataAccess;

namespace DCEwebapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure db conn using the connection string
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DCEDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add data
            services.AddScoped<CustomerDAL>(_ => new CustomerDAL(connectionString));
            services.AddScoped<OrderDAL>(_ => new OrderDAL(connectionString));

            services.AddControllers();

        }

        // HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
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
