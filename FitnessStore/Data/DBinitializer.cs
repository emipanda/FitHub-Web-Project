using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessStore.Models;

namespace FitnessStore.Data
{
    public static class DBinitializer // make it static to only create it once and not every run
    {
        public static void DBInitialize(FitnessStoreContext context)
        {
            context.Database.EnsureCreated();//checks if DB exsits. if not, will build it

            if (context.Supplier.Any() || context.Product.Any())
            {
                return;
            }
                //checking if theres data in the models
               
            var suppliers = new Supplier[]
            {
            new Supplier{Id =1, SupplierName = "Nike"},
            new Supplier {Id = 2, SupplierName = "Adidas" },//both are for clothing
            new Supplier {Id =3, SupplierName = "All In" },// for suppliments
            new Supplier {Id = 4, SupplierName = "California Gold" },//for suppliments
            new Supplier {Id =5, SupplierName = "CrossFit Plus" },
            new Supplier {Id =6, SupplierName = "Crossfit Champ" }//for gear
            };

            foreach (Supplier s in suppliers)
            {

                context.Supplier.Add(s); //adding them to the database
            }
            context.SaveChanges();//saving changes

            var storeLocations = new StoreLocation[]
            {
                new StoreLocation{x=1, y=1},
                new StoreLocation{x=1, y=1},

            };
            context.StoreLocation.AddRange(storeLocations);
            context.SaveChanges();
                      

            var products = new Product[]
            {
                new Product { ProductName = "Womens Tights", ThisProductType = ProductType.Clothing, price = 150, NumberInStock = 10, ProductSuppliers = suppliers[1], ImageURL = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/01b7720f-4c98-45d6-a450-00ca1f9bfa93/pro-365-mid-rise-crop-leggings-D31Dcj.png" },
                new Product { ProductName = "Womens  short Tights", ThisProductType = ProductType.Clothing, price = 120, NumberInStock = 7, ProductSuppliers = suppliers[1], ImageURL = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/84ca79d2-c6df-47ec-8291-61b89402d2cb/yoga-luxe-shorts-4HTfVB.png" },
                new Product { ProductName = "Mens shorts", ThisProductType = ProductType.Clothing, price = 80, NumberInStock = 5, ProductSuppliers = suppliers[2], ImageURL = "https://s1.thcdn.com/productimg/1600/1600/12517895-9734789621222323.jpg" },
                new Product { ProductName = "Mens Tank Top", ThisProductType = ProductType.Clothing, price = 70, NumberInStock = 8, ProductSuppliers = suppliers[2], ImageURL = "https://st-adidas-isr.mncdn.com/content/images/thumbs/0059481_runner-singlet_gn2164_standard-view.jpeg" },
                new Product { ProductName = "Jump rope", ThisProductType = ProductType.Training_Gear, price = 40, NumberInStock = 10, ProductSuppliers = suppliers[5], ImageURL = "https://cdn.flashyapp.com/rrd3mn/25ehAyTz.jpeg" },
                new Product { ProductName = "kettlebell", ThisProductType = ProductType.Training_Gear, price = 250, NumberInStock = 3, ProductSuppliers = suppliers[4], ImageURL = "https://d3m9l0v76dty0.cloudfront.net/system/photos/2660872/large/b8092f1639129f88c12c480817a90ecb.jpg" },
                new Product { ProductName = "Barbell", ThisProductType = ProductType.Training_Gear, price = 280, NumberInStock = 11, ProductSuppliers = suppliers[4], ImageURL = "https://www.hamptonfit.com/wp-content/uploads/2014/04/UB-S-125.jpg" },
                new Product { ProductName = "Pushup Handles", ThisProductType = ProductType.Training_Gear, price = 50, NumberInStock = 6, ProductSuppliers = suppliers[5], ImageURL = "https://superpharmstorage.blob.core.windows.net/hybris/products/desktop/medium/7299002678871.jpg" },
                new Product { ProductName = "Whey protein powder", ThisProductType = ProductType.Supplement, price = 150, NumberInStock = 10, ProductSuppliers = suppliers[3], ImageURL = "https://superpharmstorage.blob.core.windows.net/hybris/products/desktop/medium/7290111601866.jpg" },
                new Product { ProductName = "BCAA Tablets", ThisProductType = ProductType.Supplement, price = 110, NumberInStock = 12, ProductSuppliers = suppliers[3], ImageURL = "https://www.biogaya.co.il/media/catalog/product/cache/cd836a4499ae9487d98da081443bcceb/u/n/untitled-3-2.png" },
                new Product { ProductName = "Vegan Protein Powder - Vanilla", ThisProductType = ProductType.Supplement, price = 180, NumberInStock = 3, ProductSuppliers = suppliers[4], ImageURL = "https://s3.images-iherb.com/cgn/cgn01350/w/10.jpg" },
                new Product { ProductName = "Vegan Protein Powder - Chocolat", ThisProductType = ProductType.Supplement, price = 180, NumberInStock = 4, ProductSuppliers =  suppliers[4], ImageURL = "https://s3.images-iherb.com/cgn/cgn01348/w/3.jpg" },
            };
            foreach (Product p in products)
            {

                context.Product.Add(p); //adding them to the database
            }
            context.SaveChanges();//saving changes



            if (context.User.Any())
            {
                return;
            }
            

            var users = new User[]
            {
                new User {Id =1 ,UserName = "DanTheBoss", Email ="ytal151@gmail.com", Password = "danspass123", FirstName ="Dan", LastName ="Cohen", IsManager = true},
                new User {Id =2, UserName = "Emily123", Email ="emily@gmail.com", Password = "emilypass123", FirstName ="Emily", LastName ="Cohen", IsManager = false},
                new User {Id = 3, UserName = "Adi123", Email ="Adi@gmail.com", Password = "adispass123", FirstName ="Adi", LastName ="Cohen", IsManager = false},
                new User {Id = 4, UserName = "Gal123", Email ="Gal@gmail.com", Password = "galspass123", FirstName ="Gal", LastName ="Cohen", IsManager = false},
                new User {Id = 5, UserName = "Ytal23", Email ="Ytal151@gmail.com", Password = "ytalspass123", FirstName ="Ytal", LastName ="Cohen", IsManager = false},

            };
            foreach (User u in users)
            {

                context.User.Add(u); //adding them to the database
            }
            context.SaveChanges();//saving changes
            }
            /*
            if (!context.ShoppingCart.Any())
            {
                var productsForCartTwo = new Product[]
                {
                  new Product { ProductName = "Womens Tights", ThisProductType = ProductType.Clothing, price = 150, NumberInStock = 10, ProductSuppliers = "Nike", ImageURL = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/01b7720f-4c98-45d6-a450-00ca1f9bfa93/pro-365-mid-rise-crop-leggings-D31Dcj.png" },
                  new Product { ProductName = "Womens  short Tights", ThisProductType = ProductType.Clothing, price = 120, NumberInStock = 7, ProductSuppliers = "Nike", ImageURL = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/84ca79d2-c6df-47ec-8291-61b89402d2cb/yoga-luxe-shorts-4HTfVB.png" },
                  new Product { ProductName = "Vegan Protein Powder - Vanilla", ThisProductType = ProductType.Supplement, price = 180, NumberInStock = 3, ProductSuppliers = "California Gold", ImageURL = "https://s3.images-iherb.com/cgn/cgn01350/w/10.jpg" },

                };
                var productsForCartThree = new Product[]
            {
                 new Product { ProductName = "Mens Tank Top", ThisProductType = ProductType.Clothing, price = 70, NumberInStock = 8, ProductSuppliers = "Adidas", ImageURL = "https://st-adidas-isr.mncdn.com/content/images/thumbs/0059481_runner-singlet_gn2164_standard-view.jpeg" },
                new Product { ProductName = "Jump rope", ThisProductType = ProductType.Training_Gear, price = 40, NumberInStock = 10, ProductSuppliers = "Crossfit Champ", ImageURL = "https://cdn.flashyapp.com/rrd3mn/25ehAyTz.jpeg" },
                new Product { ProductName = "kettlebell", ThisProductType = ProductType.Training_Gear, price = 250, NumberInStock = 3, ProductSuppliers = "CrossFit Plus", ImageURL = "https://d3m9l0v76dty0.cloudfront.net/system/photos/2660872/large/b8092f1639129f88c12c480817a90ecb.jpg" },

            };
                var productsForCartFour = new Product[]
{
                new Product { ProductName = "Pushup Handles", ThisProductType = ProductType.Training_Gear, price = 50, NumberInStock = 6, ProductSuppliers = "Crossfit Champ", ImageURL = "https://superpharmstorage.blob.core.windows.net/hybris/products/desktop/medium/7299002678871.jpg" },
                new Product { ProductName = "Whey protein powder", ThisProductType = ProductType.Supplement, price = 150, NumberInStock = 10, ProductSuppliers = "All In", ImageURL = "https://superpharmstorage.blob.core.windows.net/hybris/products/desktop/medium/7290111601866.jpg" },
                new Product { ProductName = "BCAA Tablets", ThisProductType = ProductType.Supplement, price = 110, NumberInStock = 12, ProductSuppliers = "All In", ImageURL = "https://www.biogaya.co.il/media/catalog/product/cache/cd836a4499ae9487d98da081443bcceb/u/n/untitled-3-2.png" },
};

                var shoppingcarts = new ShoppingCart[]
                {

                    new ShoppingCart {ID = 2, UserID =2, Products = productsForCartTwo },
                    new ShoppingCart {ID = 3, UserID =3, Products = productsForCartThree },
                    new ShoppingCart {ID = 4, UserID =4, Products = productsForCartFour },

                };
                foreach (ShoppingCart s in shoppingcarts)
                {

                    context.ShoppingCart.Add(s); //adding them to the database
                }
                context.SaveChanges();//saving changes
            }
            */
        }

        }
    


      
    
