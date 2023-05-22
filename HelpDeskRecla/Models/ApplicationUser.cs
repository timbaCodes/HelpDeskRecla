using Microsoft.AspNetCore.Identity;

namespace HelpDeskIdentity.Models.HelpDeskModels
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
