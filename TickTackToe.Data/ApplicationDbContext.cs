using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TickTackToe.Shared.Entities;

namespace TickTackToe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<Note> Note { get; set; }
    }
}
