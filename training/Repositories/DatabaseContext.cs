﻿using Microsoft.EntityFrameworkCore;
using Boilerplate.Entities;

namespace Boilerplate.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
