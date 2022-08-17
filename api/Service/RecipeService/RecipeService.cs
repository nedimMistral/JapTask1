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

        public async Task<ServiceResponse<Recipe>> Create(AddRecipeDto newRecipe)
        {
            var res = new ServiceResponse<Recipe>();

            try
            {
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
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }

            return res;
        }

        public async Task<ServiceResponse<List<GetRecipeDto>>> GetRecipesByCategory(int categoryId)
        {
            var res = new ServiceResponse<List<GetRecipeDto>>();

            try
            {
                var recipeRecords = await _ctx.Recipes
            .Where(r => r.CategoryId == categoryId)
            .ToListAsync();

                res.Data = recipeRecords.Select(r => _mapper.Map<GetRecipeDto>(r))
                    .OrderBy(r => r.Price)
                    .ToList();
            }
            catch (Exception ex)
            {

                res.Success = false;
                res.Message = ex.Message;
            }


            return res;
        }

        public async Task<ServiceResponse<List<GetRecipeDto>>> SearchRecipes(string searchTerm, int index, int categoryId)
        {
            var res = new ServiceResponse<List<GetRecipeDto>>();

            try
            {
                var recipesRecord = await _ctx.Recipes
            .Include(x => x.RecipeIngredients)
            .ThenInclude(y => y.Ingredient)
            .Where(Filter(searchTerm, categoryId))
            .Take(index).ToListAsync();

                int list_count = recipesRecord.Count;

                res.Data = recipesRecord.Select(r => _mapper.Map<GetRecipeDto>(r))
                    .OrderBy(r => r.Price)
                    .ToList();
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }

            return res;
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

        public async Task<ServiceResponse<GetRecipeDetailsDto>> Details(int id)
        {
            var res = new ServiceResponse<GetRecipeDetailsDto>();

            try
            {
                var recipeRecord = await _ctx.Recipes
                                .Include(r => r.RecipeIngredients)
                                .ThenInclude(ri => ri.Ingredient)
                                .Include(c => c.Category)
                                .FirstOrDefaultAsync(r => r.Id == id);

                var ingredients = recipeRecord.RecipeIngredients.Select(ri => new RecipeIngredientDto
                {
                    IngredientName = ri.Ingredient.Name,
                    Quantity = ri.Quantity,
                    Price = ri.Price,
                    MeasureUnit = ri.Ingredient.UnitOfMeasure
                }).ToList();

                res.Data = _mapper.Map<GetRecipeDetailsDto>(recipeRecord);
                res.Data.Category = recipeRecord.Category.Name;
                res.Data.Ingredients = ingredients;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }

            return res;
        }
    }
}