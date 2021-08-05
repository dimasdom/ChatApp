using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Context
{
    public class UserContext : DbContext
    {
        public UserContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; } 
    }
}
