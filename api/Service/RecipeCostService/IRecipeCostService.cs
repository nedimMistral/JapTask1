using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Service.RecipeCostService
{
    public interface IRecipeCostService
    {
        public double CalculatePrice(List<RecipeIngredient> ingredients);
    }
}