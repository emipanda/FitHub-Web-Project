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
    public class User
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[ForeignKey("Id")]

        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Full name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required]
        //[EmailAddress]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string Email { get; set; }


        [JsonIgnore]
        [Required]
        [DataType(DataType.Password)] // SHA-256 encrypted

        public string Password { get; set; }

        [DisplayName("Manager ?")]
        public bool IsManager { get; set; }

        public virtual ShoppingCart UserCart { get; set; }

        [ForeignKey("UserCart")]
        public int UserCartId { get; set; }
    }
}


