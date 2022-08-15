using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Recipe : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PrepTimeMinutes { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}