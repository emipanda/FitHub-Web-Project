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
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Product's name cannot exceed 50 characters.")]
        public string ProductName { get; set; }

        [Required]
        public ProductType ThisProductType { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "The price must be between 0 and 1000")]
        public int price { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "The number in stock must be between 0 and 100")]
        public int NumberInStock { get; set; }

        //to post a photo of the product to show customers
        //[IsUpdatable]
        [DataType(DataType.Url)]
        [DisplayName("Image")]
        public string ImageURL { get; set; }


        public virtual Supplier ProductSuppliers { get; set; }

        [ForeignKey("ProductSuppliers")]
        public int ProductSuppliersId { get; set; }


    }
}
