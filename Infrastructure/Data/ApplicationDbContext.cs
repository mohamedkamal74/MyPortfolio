using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(e => e.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PrtofolioItem>().Property(e => e.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    FullName="Mohamed Kamal",
                    JobTitle = "Web Developer-.net Core",
                    profile= "avatar.jpg"

                }) ; 
        }
        //public DbSet<Address> Address { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PrtofolioItem> PrtofolioItems { get; set; }
    }
}
