using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace api.Data.DataSeeder
{
    public static class IngredientsSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Ingredient> ingredients = new List<Ingredient>()
            {
                new Ingredient{
                    Id = 1,
                    Name = "Baking powder",
                    UnitOfMeasure = UOM.teaspoon,
                    UnitPrice = 0.1,
                },
                new Ingredient{
                    Id = 2,
                    Name = "Eggs",
                    UnitOfMeasure = UOM.piece,
                    UnitPrice = 0.3,
                },
                new Ingredient{
                    Id = 3,
                    Name = "All-purpose flour",
                    UnitOfMeasure = UOM.gram,
                    UnitPrice = 0.1,
                },
                new Ingredient{
                    Id = 4,
                    Name = "Raising",
                    UnitOfMeasure = UOM.gram,
                    UnitPrice = 0.1,
                },
                new Ingredient{
                    Id = 5,
                    Name = "Milk",
                    UnitOfMeasure = UOM.liter,
                    UnitPrice = 2,
                },
                new Ingredient{
                    Id = 6,
                    Name = "Banana",
                    UnitOfMeasure = UOM.piece,
                    UnitPrice = 0.5,
                },
                new Ingredient{
                    Id = 7,
                    Name = "Vanila extract",
                    UnitOfMeasure = UOM.milliliter,
                    UnitPrice = 0.5,
                },
                new Ingredient{
                    Id = 8,
                    Name = "Oil",
                    UnitOfMeasure = UOM.teaspoon,
                    UnitPrice = 0.5,
                },
                new Ingredient{
                    Id = 9,
                    Name = "Olive oil",
                    UnitOfMeasure = UOM.teaspoon,
                    UnitPrice = 1,
                },
                new Ingredient{
                    Id = 10,
                    Name = "Onions",
                    UnitOfMeasure = UOM.piece,
                    UnitPrice = 0.3,
                },
                new Ingredient{
                    Id = 11,
                    Name = "Water",
                    UnitOfMeasure = UOM.milliliter,
                    UnitPrice = 0.0,
                },
                new Ingredient{
                    Id = 12,
                    Name = "Salt",
                    UnitOfMeasure = UOM.teaspoon,
                    UnitPrice = 0.1,
                },
                new Ingredient{
                    Id = 13,
                    Name = "Thyme",
                    UnitOfMeasure = UOM.teaspoon,
                    UnitPrice = 0.2,
                },
            };
            modelBuilder.Entity<Ingredient>().HasData(ingredients);
        }      
    }
}