using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.DataSeeder;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RecipeIngredient>()
                .HasOne(r => r.Recipe)
                    .WithMany(ri => ri.RecipeIngredients)
                        .HasForeignKey(ri => ri.RecipeId);

            DataSeeder.CategoriesSeed.Seed(builder);
            DataSeeder.IngredientsSeed.Seed(builder);

        }
    }
}