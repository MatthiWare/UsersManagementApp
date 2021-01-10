using MatthiWare.CommandLine.Abstractions.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UsersManagementApp.Models;
using UsersManagementApp.Services;

namespace UsersManagementApp.Commands
{
    public class RegisterCommand : Command<GlobalOptions, RegisterOptions>
    {
        private readonly IUserService userService;

        public RegisterCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public override void OnConfigure(ICommandConfigurationBuilder builder)
        {
            builder.Name("register").Description("Registers a new user to the database");
        }

        public override async Task OnExecuteAsync(GlobalOptions options, RegisterOptions register, CancellationToken cancellationToken)
        {
            var user = await userService.RegisterUserAsync(register.Username, register.Password);

            if (options.Verbose)
            {
                Console.WriteLine($"User {user.Username} registered with id of {user.Id}!");
            }
            else
            {
                Console.WriteLine("User registered!");
            }
        }
    }
}
