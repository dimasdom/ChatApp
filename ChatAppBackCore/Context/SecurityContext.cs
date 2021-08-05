using ChatAppBackCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppBackCore.Context
{
    public class SecurityContext : IdentityDbContext<User>
    {
        public SecurityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
