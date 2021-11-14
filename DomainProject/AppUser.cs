using Microsoft.AspNetCore.Identity;
using System;

namespace DomainProject
{
    public class AppUser: IdentityUser
    {
        public DateTime? BirthDate { get; set; }
    }
}
