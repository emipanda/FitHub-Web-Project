using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
//using FitnessStore.Utils;

namespace FitnessStore.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public virtual User User{ get; set; }
        public ICollection<Product> Products { get; set; }
        //see lecture 8 minute 40 if there are problmes with this and the data  base
        public static DateTime Now { get; } //time of creataion of the cart
                                            //needed to calculate delivery time
        public int TotalPrice
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    sum = sum + Products.ElementAt(i).price;
                }
                return sum;
            }

        }

        public static DateTime OrderReadyBy
            //orders are ready for pick up after 1 business day
        {
            get
            {
                if (Now.DayOfWeek == DayOfWeek.Friday)
                    return (Now.AddDays(2));
                else
                    return (Now.AddDays(1));

            }
        }
    }
}

