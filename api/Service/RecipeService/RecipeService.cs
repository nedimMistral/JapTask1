using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Service.RecipeCostService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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

            await _ctx.SaveChangesAsync();

            res.Data = recipeRecord;

            return res;
        }

        public async Task<ActionResult<ServiceResponse<List<GetRecipeDto>>>> GetRecipesByCategory(int categoryId)
        {
            var res = new ServiceResponse<List<GetRecipeDto>>();

            var recipeRecords = await _ctx.Recipes
                .Where(r => r.CategoryId == categoryId)
                .ToListAsync();
            
            res.Data = recipeRecords.Select(r => _mapper.Map<GetRecipeDto>(r))
                .OrderBy(r => r.Price)
                .ToList();
            
            return res;        
        }

        public async Task<ActionResult<ServiceResponse<List<GetRecipeDto>>>> GetRecipes(string searchTerm, int index, int categoryId)
        {
            var res = new ServiceResponse<List<GetRecipeDto>>();

            var recipesRecord = await _ctx.Recipes
            .Include(x => x.RecipeIngredients)
            .ThenInclude(y => y.Ingredient)
            .Where(Filter(searchTerm, categoryId))
            .Take(index).ToListAsync();


            throw new NotImplementedException();
        }

        private static Expression<Func<Recipe, bool>> Filter(string term, int categoryId)
        {
            term = term?.Trim().ToLower();
            return x => x.CategoryId == categoryId &&
            (string.IsNullOrEmpty(term)
            || x.Title.ToLower().Contains(term)
            || x.Description.ToLower().Contains(term)
            || x.RecipeIngredients.Any(y => y.Ingredient.Name.ToLower().Contains(term)));
        }


    }
}