using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Models;

namespace api.Models
{
    public class Ingredient : BaseModel
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double UnitQuantity { get; set; }
        public UOM UnitOfMeasure { get; set; }
    }
}