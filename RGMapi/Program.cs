using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using RGMapi.Models.EntityFramework;
using SAE_4._01.Models.DataManager; // Tu utilise pas le bon DataManager, celui là est celui de la SAE et ne convient donc pas car bon nom de projet
using RGMapi.Models.Repository;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography.Pkcs;
using System.Transactions;

namespace SAE_4._01 // ????????? C'est pas compatible, t'as pas pensé a changer tes noms de namespace en faisant tes copié coller.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RgmContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("SeriesDbContextRemote")));

            builder.Services.AddScoped<IDataRepository<Lien>, LienManager>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyHeader();
                    });
            });



            // services.AddResponseCaching();  

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowAll");

            app.Run();
        }
    }
}
