using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;


namespace api.Dtos
{
    public class AddRecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public UOM MeasureUnit { get; set; }
    }
}