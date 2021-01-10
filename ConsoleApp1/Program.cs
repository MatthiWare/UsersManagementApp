using UsersManagementApp.Data;
using UsersManagementApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;

namespace UsersManagementApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
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
