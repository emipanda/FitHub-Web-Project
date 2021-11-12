using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessStore;
using FitnessStore.Models;
using FitnessStore.ViewModels;
using FitnessStore.Data;
using FitnessStore.Repositories;

namespace FitnessStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly FitnessStoreContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository,
            ShoppingCart shoppingCart, FitnessStoreContext context)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public async Task<IActionResult> AddToShoppingCart(int pizzaId)
        {
            var selectedPizza = await _productRepository.GetByIdAsync(pizzaId);

            if (selectedPizza != null)
            {
                await _shoppingCart.AddToCartAsync(selectedPizza, 1);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromShoppingCart(int pizzaId)
        {
            var selectedPizza = await _productRepository.GetByIdAsync(pizzaId);

            if (selectedPizza != null)
            {
                await _shoppingCart.RemoveFromCartAsync(selectedPizza);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearCart()
        {
            await _shoppingCart.ClearCartAsync();

            return RedirectToAction("Index");
        }

    }
}