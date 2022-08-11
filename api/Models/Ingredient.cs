using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Models;

namespace api.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public float UnitQuantity { get; set; }
        public UOM UnitOfMeasure { get; set; }
    }
}