using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Walker> Walkers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var belloId = Guid.Parse("aa8249ec-7e6e-408e-a834-72280823cefd");
            var ownerId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    Id = ownerId, // Die ID, auf die Bello gleich verweisen wird
                    Name = "Henry Habib",
                    Email = "habib@gmail.com",
                    Address = "123 Dog Street, Bochum"
                }
            );

            modelBuilder.Entity<Dog>().HasData(
                new Dog
                {
                    Id = belloId, // Bleibt für immer gleich
                    Name = "Bello",
                    Breed = "Labrador Retriever",
                    Gender = "M",
                    PhotoUrl = "Bello.jpg",
                    OwnerId = ownerId
                }
            );

 
            modelBuilder.Entity<Dog>()
            .HasOne(d => d.Owner)
            .WithMany(o => o.Dogs)
            .HasForeignKey(d => d.OwnerId);

            modelBuilder.Entity<Trip>()
            .HasOne(t => t.Walker)
            .WithMany(w => w.Trips)
            .HasForeignKey(t => t.WalkerId);
        }
    }
}