using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace api.Dtos
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double UnitQuantity { get; set; }
        public UOM UnitOfMeasure { get; set; }
    }
}