using FitnessStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessStore.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        [DisplayName("Serach")]
        public string SearchText { get; set; }

        //public IEnumerable<string> SearchListExamples { get; set; }

        public IEnumerable<Product> ProductList { get; set; }

    }
}
