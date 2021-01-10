using MatthiWare.CommandLine.Core.Attributes;

namespace UsersManagementApp.Models
{
    public class RegisterOptions
    {
        [Name("u", "username"), Required, Description("Username"), OptionOrder(0)]
        public string Username { get; set; }

        [Name("p", "password"), Required, Description("Password"), OptionOrder(1)]
        public string Password { get; set; }
    }
}
