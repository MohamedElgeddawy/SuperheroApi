using Microsoft.AspNetCore.Identity;
namespace SuperheroApi.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
