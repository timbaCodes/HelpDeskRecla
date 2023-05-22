using HelpDesk2023.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskIdentity.Models.HelpDeskModels
{
    public class DeskDbContext : IdentityDbContext
    {
        public DeskDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ReclamationEntity> Reclamation { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
