using MessageService.Models.Chat;
using MessageService.Models.Message;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Context
{
    public class MassageServiceContext : DbContext
    {
        public MassageServiceContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}
