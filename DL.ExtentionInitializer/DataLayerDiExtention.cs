
using DL.ApiInterfaces;
using DL.ApiRepositories;
using DL.DatabaseContext;
using DL.IUnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DL.ExtentionInitializer
{
    public static class DataLayerDiExtention
    {
        private static IServiceCollection _services;

        public static void RegisterDataLayerDependency(this IServiceCollection services)
        {
            _services = services;
            
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseNpgsql(config.GetConnectionString("DatabaseConnection"));
                    options.EnableSensitiveDataLogging(false);
                });

            services.AddTransient(typeof(IUnitOfWork.IUnitOfWork), typeof(UnitOfWork.UnitOfWork));

            services.AddScoped<IQuestionRepository, QuestionRepository>();
        }
    }
}
