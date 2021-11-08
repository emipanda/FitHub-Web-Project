using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessStore.Models;

namespace FitnessStore.Data
{
    public class FitnessStoreContext : DbContext
    {
        public FitnessStoreContext (DbContextOptions<FitnessStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreLocation>().HasNoKey();
            modelBuilder.Entity<Supplier>().HasKey(s => s.Id);

            modelBuilder.Entity<Product>().HasOne<Supplier>(p => p.ProductSuppliers);

            modelBuilder.Entity<ShoppingCart>().HasKey(s => s.ID);
            modelBuilder.Entity<User>().HasOne<ShoppingCart>(u => u.UserCart).WithOne(c => c.User);
        }

        public DbSet<FitnessStore.Models.Product> Product { get; set; }

        public DbSet<FitnessStore.Models.Supplier> Supplier { get; set; }

        public DbSet<FitnessStore.Models.StoreLocation> StoreLocation{ get; set; }


        public DbSet<FitnessStore.Models.ShoppingCart> ShoppingCart { get; set; }

        public DbSet<FitnessStore.Models.User> User { get; set; }

    }

    //FitnessStoreContext context;

}
