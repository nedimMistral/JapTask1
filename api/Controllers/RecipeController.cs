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
        private readonly IRecipeService _recipeSvc;

        public RecipeController(IRecipeService recipeSvc)
        {
            _recipeSvc = recipeSvc;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Recipe>>> AddNew(AddRecipeDto newRecipe)
        {
            return Ok(await _recipeSvc.Create(newRecipe));
        }

        [HttpGet("ByCategory")]
        public async Task<ActionResult<ServiceResponse<List<GetRecipeDto>>>> ListByCategory([FromQuery] int categoryId)
        {
            return Ok(await _recipeSvc.GetRecipesByCategory(categoryId));
        }

        [HttpGet("Search")]
        public async Task<ActionResult<ServiceResponse<List<GetRecipeDto>>>> GetWithSearch([FromQuery] string searchTerm, [FromQuery] int index, [FromQuery] int categoryId)
        {
            return Ok(await _recipeSvc.SearchRecipes(searchTerm, index, categoryId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetRecipeDetailsDto>>> GetDetailed(int id)
        {
            var res = await _recipeSvc.Details(id);

            if (res.Data == null) {
                return NotFound(res);
            }

            return Ok(res);
        }
    }
}