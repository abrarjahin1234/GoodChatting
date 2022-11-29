﻿using GoodChatting.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodChatting.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>().HasOne<AppUser>(s=>s.AppUser)
                .WithMany(d=>d.Messages)
                .HasForeignKey(d=>d.UserId);
        }
        public DbSet<Message> Messages { get; set; }    
    }
}
