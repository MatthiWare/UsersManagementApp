using MatthiWare.CommandLine.Core.Attributes;

namespace UsersManagementApp.Models
{
    public class GlobalOptions
    {
        [Name("v", "verbose"), DefaultValue(false), Description("Verbose output")]
        public bool Verbose { get; set; }

        [Name("a"), DefaultValue(100), Description("Something a")]
        public int A { get; set; }

        [Name("b"), DefaultValue(200), Description("Something b")]
        public int B { get; set; }

        [Name("c"), DefaultValue(300), Description("Something c")]
        public int C { get; set; }
    }
}
