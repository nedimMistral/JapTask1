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
        public Task<ActionResult<ServiceResponse<Recipe>>> Create(AddRecipeDto newRecipe);
        public Task<ActionResult<ServiceResponse<List<GetRecipeDto>>>> GetRecipesByCategory(int categoryId);
        public Task<ActionResult<ServiceResponse<List<GetRecipeDto>>>> GetRecipes(string searchTerm, int index, int categoryId);
    }
}