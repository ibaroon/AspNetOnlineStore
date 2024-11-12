using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models
{
    public class UserRolesVm
    {  //prop for properties
       //ctor for constructor
        public UserRolesVm()
        {
            userRoles = new List<string>();
        }
        public IdentityUser user {  get; set; } 
        public List<string> userRoles { get; set; } 
    }
}
