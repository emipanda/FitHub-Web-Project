using FitnessStore.Data;
using FitnessStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FitnessStoreContext _context;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(FitnessStoreContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            decimal totalPrice = 0M;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.Id,
                    Order = order,
                    Price = shoppingCartItem.Product.Price,
                    
                };
                totalPrice += orderDetail.Price * orderDetail.Amount;
                _context.OrderDetails.Add(orderDetail);
            }

            order.OrderTotal = totalPrice;
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
        }
    }
}
