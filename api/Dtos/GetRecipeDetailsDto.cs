using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class GetRecipeDetailsDto
    {
        public int Id { get; set; }
        public string Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public int PrepTimeMinutes { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<RecipeIngredientDto> Ingredients { get; set; }
    }
}