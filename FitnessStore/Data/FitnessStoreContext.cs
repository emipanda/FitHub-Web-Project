using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FitnessStore.Data
{
    public class FitnessStoreContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessStoreContext (DbContextOptions<FitnessStoreContext> options) : base(options) { }


        public DbSet<FitnessStore.Models.Product> Products { get; set; }

        public DbSet<FitnessStore.Models.Supplier> Supplier { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<FitnessStore.Models.StoreLocation> StoreLocation{ get; set; }


        public DbSet<FitnessStore.Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }

    //FitnessStoreContext context;

}
