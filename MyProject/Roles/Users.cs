using Microsoft.AspNetCore.Identity;

namespace MyProject.Roles
{
    public class Users : IdentityUser
    {

        public string FullName { get; set; }
    }
}
