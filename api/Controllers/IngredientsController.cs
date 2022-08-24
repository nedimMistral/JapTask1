using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Service.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientsSvc;

        public IngredientsController(IIngredientService ingredientsSvc)
        {
            _ingredientsSvc = ingredientsSvc;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<IngredientDto>>>> Get()
        {
            return Ok(await _ingredientsSvc.Get());
        }

    }
}