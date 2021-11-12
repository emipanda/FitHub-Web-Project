using System;
using System.Collections.Generic;
using System.Linq;
using FitnessStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessStore.Data
{
    public class DbInitializer
    {
        public static void Initialize(FitnessStoreContext context, IServiceProvider service)
        {
            context.Database.EnsureCreated();

            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();

            if (context.Products.Any())
            {
                return;
            }

            ClearDatabase(context);
            CreateAdminRole(context, roleManager, userManager);
            SeedDatabase(context, roleManager, userManager);
        }

        private static void CreateAdminRole(FitnessStoreContext context, RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            bool roleExists = _roleManager.RoleExistsAsync("Admin").Result;
            if (roleExists)
            {
                return;
            }

            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            _roleManager.CreateAsync(role).Wait();

            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "admin@default.com"
            };

            string adminPassword = "Password123";
            var userResult = _userManager.CreateAsync(user, adminPassword).Result;

            if (userResult.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        private static void SeedDatabase(FitnessStoreContext _context, RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
           /* var cat1 = new Categories { Name = "Standard", Description = "The Bakery's Standard pizzas all year around." };
            var cat2 = new Categories { Name = "Spcialities", Description = "The Bakery's Speciality pizzas only for a limited time." };
            var cat3 = new Categories { Name = "News", Description = "The Bakery's New pizzas on the menu." };

            var cats = new List<Categories>()
            {
                cat1, cat2, cat3
            };*/

            var prod1 = new Product { ProductName = "Capricciosa", Price = 70.00M, Description = "A normal pizza with a taste from the forest.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/Pizza_capricciosa.jpg"};
            var prod2 = new Product { ProductName = "Veggie", Price = 70.00M, Description = "Veggie Pizza for vegitarians", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Vegetarian_pizza.jpg"};
            var prod3 = new Product { ProductName = "Hawaii", Price = 75.00M, Description = "A nice tasting pizza from Hawaii.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Hawaiian_pizza_1.jpg"};
            var prod4 = new Product { ProductName = "Margarita", Price = 65.00M, Description = "A basic pizza for everyone.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Eq_it-na_pizza-margherita_sep2005_sml.jpg" };
            var prod5 = new Product { ProductName = "Kebab Special", Price = 85.00M, Description = "A special pizza with kebab for the hungry one.", ImageUrl = "http://2.bp.blogspot.com/_3cSn3Qz_4IA/THkYqKwGw1I/AAAAAAAAAPg/ybKpvRbjDWE/s1600/matsl%C3%A4kten+002.JPG"};
            var prod6 = new Product { ProductName = "Pescatore", Price = 80.00M, Description = "A pizza with taste from the ocean.", ImageUrl = "https://isinginthekitchen.files.wordpress.com/2014/07/dsc_0231.jpg" };
            var prod7 = new Product { ProductName = "Barcelona", Price = 70.00M, Description = "A pizza with taste from Spain, Barcelona", ImageUrl = "http://barcelona-home.com/blog/wp-content/upload/pizza/Pizzeria%20Los%20Amigos/pizza-jamon-dulce-y-champinone.jpg" };
            var prod8 = new Product { ProductName = "Flying Jacob", Price = 89.00M, Description = "Flying pizza from the sky, with taste of banana.", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/64/Pizza_Hawaii_Special_p%C3%A5_Pizzeria_Papillon_i_Sala_1343.jpg" };
            var prod9 = new Product { ProductName = "Kentucky", Price = 69.00M, Description = "A pizza from America with the taste of Kuntucky Chicken.", ImageUrl = "http://assets.kraftfoods.com/recipe_images/opendeploy/54150_640x428.jpg"};
            var prod10 = new Product { ProductName = "La Carne", Price = 75.00M,Description = "Italian pizza with lot's of delicious meat.", ImageUrl = "https://www.davannis.com/wp-content/uploads/2015/03/five-meat.jpg"};

            var prods = new List<Product>()
            {
                prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9, prod10
            };

            var user1 = new ApplicationUser { UserName = "user1@gmail.com", Email = "user1@gmail.com" };
            var user2 = new ApplicationUser { UserName = "user2@gmail.com", Email = "user2@gmail.com" };
            var user3 = new ApplicationUser { UserName = "user3@gmail.com", Email = "user3@gmail.com" };
            var user4 = new ApplicationUser { UserName = "user4@gmail.com", Email = "user4@gmail.com" };
            var user5 = new ApplicationUser { UserName = "user5@gmail.com", Email = "user5@gmail.com" };

            string userPassword = "Password123";

            var users = new List<ApplicationUser>()
            {
                user1, user2, user3, user4, user5
            };

            foreach (var user in users)
            {
                _userManager.CreateAsync(user, userPassword).Wait();
            }



            var ord1 = new Order
            {
                FirstName = "Pelle",
                LastName = "Andersson",
                AddressLine1 = "MainStreet 12",
                City = "Gothenburg",
                Country = "Sweden",
                Email = "pelle22@gmail.com",
                OrderPlaced = DateTime.Now.AddDays(-2),
                PhoneNumber = "0705123456",
                User = user1,
                ZipCode = "43210",
                OrderTotal = 370.00M,
            };

            var ord2 = new Order { };
            var ord3 = new Order { };

            var orderLines = new List<OrderDetail>()
            {
                new OrderDetail { Order=ord1, Product=prod1, Amount=2, Price=prod1.Price},
                new OrderDetail { Order=ord1, Product=prod3, Amount=1, Price=prod3.Price},
                new OrderDetail { Order=ord1, Product=prod5, Amount=3, Price=prod5.Price},
            };

            var orders = new List<Order>()
            {
                ord1
            };

            /*_context.Categories.AddRange(cats);*/
            _context.Products.AddRange(prods);
            _context.Orders.AddRange(orders);
            _context.OrderDetails.AddRange(orderLines);

            _context.SaveChanges();
        }

        private static void ClearDatabase(FitnessStoreContext _context)
        {

            var shoppingCartItems = _context.ShoppingCartItems.ToList();
            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            foreach (var user in users)
            {
                if (!userRoles.Any(r => r.UserId == user.Id))
                {
                    _context.Users.Remove(user);
                }
            }

            var orderDetails = _context.OrderDetails.ToList();
            _context.OrderDetails.RemoveRange(orderDetails);

            var orders = _context.Orders.ToList();
            _context.Orders.RemoveRange(orders);

            var products = _context.Products.ToList();
            _context.Products.RemoveRange(products);

          /*  var categories = _context.Categories.ToList();
            _context.Categories.RemoveRange(categories);*/

            _context.SaveChanges();
        }
    }
}