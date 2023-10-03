using ControleFornecedores.Data;
using ControleFornecedores.Models;
using ControleFornecedores.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleFornecedores
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configurar o contexto do banco de dados
            builder.Services.AddDbContext<BancoContext>(options =>
            {
                var serviceProvider = builder.Services.BuildServiceProvider();
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                options.UseSqlServer(configuration.GetConnectionString("DataBase"));
            });

            // Registrar a implementação de IFornecedorRepositorio
            builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
