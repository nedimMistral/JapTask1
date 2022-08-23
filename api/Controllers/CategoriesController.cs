using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Service.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categorySvc;

        public CategoriesController(ICategoryService categorySvc)
        {
            _categorySvc = categorySvc;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CategoriesDto>>>> Get([FromQuery] int n)
        {
            return Ok(await _categorySvc.Get(n));
        }
    }
}