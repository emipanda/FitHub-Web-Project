using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessStore.Models
{
   // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public class StoreLocation
    {
        public int x { get; set; }

        public int y{ get; set; }
    }
}
