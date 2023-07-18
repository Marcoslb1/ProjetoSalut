using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalutVaga.Interface;
using SalutVaga.Mapping;
using SalutVaga.Models;
using SalutVaga.Repositories;

namespace SalutVaga
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
            //entity/conexão de string
            services.AddDbContext<DB_SALUTContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //repository pattern -- TODO Lembrar de explicar kkk
            services.AddScoped<INotaFiscal, NotaFiscalRepository>();
            services.AddScoped<IProduto, ProdutoRepository>();
            services.AddScoped<ICanalCompra, CanalCompraRepository>();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(EntitiesToDtoMappingProfile));

        }

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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Formulario}/{action=Cadastrar}/{id?}");
            });
        }
    }
}
