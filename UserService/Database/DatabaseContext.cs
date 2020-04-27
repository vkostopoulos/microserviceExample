﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Database.Entities;

namespace UserService.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5MTTOS6\SQLEXPRESS;" +
                                                            "Initial Catalog=microserviceExample;" +
                                                            "persist security info = True;Integrated Security = SSPI;");
        }
    }
}
