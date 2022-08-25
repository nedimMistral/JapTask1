using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data.DataSeeder;
using api.Dtos;
using api.Models;
using api.Service.AuthService;
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

            var user = new User
            {
                Username = "admin"
            };

            CreatePasswordHash(out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.CreatedAt = DateTime.Now;

            builder.Entity<User>().HasData(user);

            DataSeeder.CategoriesSeed.Seed(builder);
            DataSeeder.IngredientsSeed.Seed(builder);
        }

        private void CreatePasswordHash(out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin123"));
            }
        }
    }
}