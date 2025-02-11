
using Microsoft.EntityFrameworkCore;
using ZooAPI.Data;

namespace ZooAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ZooAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQL") ?? throw new InvalidOperationException("Connection string 'SQL    ' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddDbContext<DatabaseContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policyBuilder => policyBuilder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();


        }
    }
}
