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

        public DbSet<FitnessStore.Models.Product> Product { get; set; }

        public DbSet<FitnessStore.Models.Supplier> Supplier { get; set; }

        public DbSet<FitnessStore.Models.ShoppingCart> ShoppingCart { get; set; }

        public DbSet<FitnessStore.Models.User> User { get; set; }
    }
}
