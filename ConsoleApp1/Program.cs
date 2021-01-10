using UsersManagementApp.Data;
using UsersManagementApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;
using MatthiWare.CommandLine;
using UsersManagementApp.Models;
using System.Reflection;
using MatthiWare.CommandLine.Extensions.FluentValidations;
using UsersManagementApp.Validators;

namespace UsersManagementApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var options = new CommandLineParserOptions 
            {
                AppName = "UsersManagementApp.exe"
            };

            var parser = new CommandLineParser<GlobalOptions>(options, services);

            parser.DiscoverCommands(Assembly.GetExecutingAssembly());

            parser.UseFluentValidations(config => 
            {
                config.AddValidator<RegisterOptions, RegisterValidator>();
            });

            var result = await parser.ParseAsync(args);

            if (result.HasErrors)
            {
                return;
            }

            if (result.Result.Verbose)
            {
                Console.WriteLine("Verbose specified!");
            }
        }

        static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<UserDbContext>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
