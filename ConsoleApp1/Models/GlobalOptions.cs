using MatthiWare.CommandLine.Core.Attributes;

namespace UsersManagementApp.Models
{
    public class GlobalOptions
    {
        [Name("v", "verbose"), DefaultValue(false), Description("Verbose output")]
        public bool Verbose { get; set; }
    }
}
