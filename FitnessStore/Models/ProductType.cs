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
    public enum ProductType
{
    [Description("Supplement")]
     Supplement,

    [Description("Training Gear")]
    Training_Gear,

    [Description("Clothing")]
    Clothing,
}
}