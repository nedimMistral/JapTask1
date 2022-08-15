using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Data.DataSeeder
{
    public static class CategoriesSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            List<Category> categories = new List<Category>()
            {
                new Category{
                    Id = 1,
                    Name = "Appetizers and Snacks",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)                
                },
                new Category{
                    Id = 2,
                    Name = "Breads and Breakfasts",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 3,
                    Name = "Cakes and Frostings",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 4,
                    Name = "Casseroles",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 5,
                    Name = "Condiments",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 6,
                    Name = "Cookies",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 7,
                    Name = "Desserts",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 8,
                    Name = "Diabetic Friendly",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 9,
                    Name = "Gluten Free",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 10,
                    Name = "Grilling",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 11,
                    Name = "Healthy",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 12,
                    Name = "Kids recipes",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 13,
                    Name = "Pasta",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
                new Category{
                    Id = 14,
                    Name = "Pies",
                    CreatedAt = new DateTime(2022, new Random().Next(1, 7), new Random().Next(1, 28),0,0,0)
                },
            };
            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}