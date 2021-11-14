using DomainProject;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFData
{
    public class ApplicationContext: IdentityDbContext<AppUser>
    {
        public ApplicationContext(DbContextOptions options): base(options) { }
    }
}
