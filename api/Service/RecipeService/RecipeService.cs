using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Service.RecipeCostService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Service.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        private readonly IRecipeCostService _recipeCostSvc;

        public RecipeService(DataContext ctx, IMapper mapper, IRecipeCostService recipeCostSvc)
        {
            _ctx = ctx;
            _mapper = mapper;
            _recipeCostSvc = recipeCostSvc;
        }

        public async Task<ActionResult<ServiceResponse<Recipe>>> Create(AddRecipeDto newRecipe)
        {
            var res = new ServiceResponse<Recipe>();

            var dbRecipeIngredients = newRecipe.RecipeIngredients.Select(ri => new RecipeIngredient()
            {
                IngredientId = ri.IngredientId,
                MeasureUnit = ri.MeasureUnit,
                Quantity = ri.Quantity,
                Price = ri.Price
            }).ToList();

            var recipeRecord = new Recipe
            {
                Title = newRecipe.Title,
                Description = newRecipe.Description,
                RecipeIngredients = dbRecipeIngredients,
                PrepTimeMinutes = newRecipe.PrepTimeMinutes,
                CategoryId = newRecipe.CategoryId,
                UserId = newRecipe.UserId,
                CreatedAt = DateTime.Now
            };
            
            _ctx.Recipes.Add(recipeRecord);

            recipeRecord.Price = _recipeCostSvc.CalculatePrice(dbRecipeIngredients);
            Console.WriteLine("PRICEEE::::::", recipeRecord.Price);

            await _ctx.SaveChangesAsync();
            
            res.Data = recipeRecord;

            return res;
        }
    }
}