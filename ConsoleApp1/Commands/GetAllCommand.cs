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
    public class GetAllCommand : Command<GlobalOptions>
    {
        private readonly IUserService userService;

        public GetAllCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public override void OnConfigure(ICommandConfigurationBuilder builder)
        {
            builder.Name("get-all").Description("Gets all users from the database");
        }

        public override async Task OnExecuteAsync(GlobalOptions options, CancellationToken cancellationToken)
        {
            var users = await userService.GetAllUsersAsync();

            Console.WriteLine("Users:");

            foreach (var user in users)
            {
                if (options.Verbose)
                {
                    PrintUserVerbose(user);
                }
                else
                {
                    PrintUser(user);
                }
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
