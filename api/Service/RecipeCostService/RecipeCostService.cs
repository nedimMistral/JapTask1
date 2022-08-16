using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Service.RecipeCostService
{
    public class RecipeCostService : IRecipeCostService
    {
        public double CalculatePrice(List<RecipeIngredient> ingredients)
        {
            var totalPrice = 0.0;

            foreach (var ingredient in ingredients)
            {
                totalPrice += ingredient.Quantity * ingredient.Price;
            }

            return (double)Math.Round(totalPrice, 2);
        }
    }
}