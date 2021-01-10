using MatthiWare.CommandLine.Core.Attributes;

namespace UsersManagementApp.Models
{
    public class GetUserOptions
    {
        [Name("id"), Required, Description("User id")]
        public int Id { get; set; }
    }
}
