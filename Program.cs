
using ECommerce.Models;
using ECommerce.Services;
using Microsoft.EntityFrameworkCore;


namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            var cn = builder.Configuration.GetConnectionString("DefualtConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cn));
            builder.Services.AddControllers();
            builder.Services.AddCors();
         
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();       
            builder.Services.AddTransient<IProductServ, ProductServ>();
            builder.Services.AddTransient<ICategoryServ , CategoryServ>();
            builder.Services.AddTransient<IA_Con, A_Con>();
            builder.Services.AddTransient<ICartServ, CartServ>();
            builder.Services.AddTransient<IUserServ, UserServ>();
           
            var app = builder.Build();
            


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}