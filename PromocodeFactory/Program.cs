using PromocodeFactory.Mappings;
using PromocodeFactory.Repositories;

namespace PromocodeFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();
            builder.Services.AddAutoMapper(_ => { }, typeof(EmployeeMappingProfile).Assembly);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
