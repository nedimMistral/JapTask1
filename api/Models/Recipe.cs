using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Recipe
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; } 
        public int PrepTimeMinutes { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int MyProperty { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public Category? Category { get; set; }
    }
}