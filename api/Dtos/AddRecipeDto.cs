using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class AddRecipeDto
    {
        public string Title { get; set; }
        public string Description { get; set; } 
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int PrepTimeMinutes { get; set; }
        public List<AddRecipeIngredientDto> RecipeIngredients { get; set; }

    }
}