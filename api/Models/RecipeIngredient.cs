using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace api.Models
{
    public class RecipeIngredient : BaseModel
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public UOM MeasureUnit { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

    }
}