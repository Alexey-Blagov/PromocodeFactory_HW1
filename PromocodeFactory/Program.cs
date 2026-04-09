
using Microsoft.Extensions.DependencyInjection;
using PromocodeFactory.Mappings;
using PromocodeFactory.Repositories;

namespace PromocodeFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Регистрация репозитория
            builder.Services.AddSingleton <Models.IEmployeeRepository, InMemoryEmployeeRepository>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(EmployeeMappingProfile));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.Run();
        }
    }
}
