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
    public class GetuserCommand : Command<GlobalOptions, GetUserOptions>
    {
        private readonly IUserService userService;

        public GetuserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public override void OnConfigure(ICommandConfigurationBuilder builder)
        {
            builder.Name("get").Description("Gets a user from the database");
        }

        public override async Task OnExecuteAsync(GlobalOptions options, GetUserOptions get, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserAsync(get.Id);

            if (user is null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            if (options.Verbose)
            {
                PrintUserVerbose(user);
            }
            else
            {
                PrintUser(user);
            }
        }

        private void PrintUser(UserModel user)
        {
            Console.WriteLine($" - {user.Username}");
        }

        private void PrintUserVerbose(UserModel user)
        {
            Console.WriteLine($"User id: {user.Id}");
            Console.WriteLine($" - {user.Username}");
            Console.WriteLine($" - {user.Password}");
        }
    }
}
