using Microsoft.EntityFrameworkCore;
using FitnessStore.Data;
using FitnessStore.Models;
using FitnessStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FitnessStoreContext _context;

        public ProductRepository(FitnessStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Product => _context.Products.Include(p => p.ProductName).Include(p => p.Price); //include here

        public void Add(Product product)
        {
            _context.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
/*
        public async Task<IEnumerable<Product>> GetAllIncludedAsync()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).ToListAsync();
        }

        public IEnumerable<Product> GetAllIncluded()
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).ToList();
        }*/

        public Product GetById(int? id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
/*
        public Product GetByIdIncluded(int? id)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).FirstOrDefault(p => p.Id == id);
        }

        public async Task<Product> GetByIdIncludedAsync(int? id)
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Reviews).Include(p => p.PizzaIngredients).FirstOrDefaultAsync(p => p.Id == id);
        }*/

        public bool Exists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        public void Remove(Product pizza)
        {
            _context.Remove(pizza);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Product pizza)
        {
            _context.Update(pizza);
        }

    }
}
