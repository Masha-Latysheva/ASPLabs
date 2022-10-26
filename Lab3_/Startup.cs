using Lab3_.Data;
using Lab3_.Middleware;
using Lab3_.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab3_
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
            // внедрение зависимости для доступа к БД с использованием EF
            var connection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<LogisticContext>(options => options.UseSqlServer(connection));
            // внедрение зависимости OperationService
            services.AddTransient<ICarsService, CarsService>();
            // добавление кэширования
            services.AddMemoryCache();
            // добавление поддержки сессии
            services.AddDistributedMemoryCache();
            services.AddSession();

            //Использование MVC
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            // добавляем поддержку статических файлов
            app.UseStaticFiles();

            // добавляем поддержку сессий
            app.UseSession();

            app.UseMiddleware<InfoMiddleware>();

            // добавляем компонент middleware по инициализации базы данных и производим инициализацию базы
            app.UseDbInitializer();

            // добавляем компонент middleware для реализации кэширования и записывем данные в кэш
            app.UseOperatinCache("Cars 10");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}