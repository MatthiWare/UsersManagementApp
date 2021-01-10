using MatthiWare.CommandLine.Core.Attributes;

namespace UsersManagementApp.Models
{
    public class RegisterOptions
    {
        [Name("u", "username"), Required, Description("Username")]
        public string Username { get; set; }

        [Name("p", "password"), Required, Description("Password")]
        public string Password { get; set; }
    }
}
