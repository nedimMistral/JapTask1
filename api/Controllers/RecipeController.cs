using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Service.RecipeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Recipe>>> AddNew(AddRecipeDto newRecipe)
        {
            return Ok(await _recipeService.Create(newRecipe));
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<
    }
}