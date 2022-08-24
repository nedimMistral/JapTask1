using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Service.RecipeService
{
    public interface IRecipeService
    {
        public Task<ServiceResponse<Recipe>> Create(AddRecipeDto newRecipe);
        public Task<ServiceResponse<List<GetRecipeDto>>> GetRecipesByCategory(int categoryId, int n);
        public Task<ServiceResponse<List<GetRecipeDto>>> SearchRecipes(string searchTerm, int index, int categoryId);
        public Task<ServiceResponse<GetRecipeDetailsDto>> Details(int id);
    }
}