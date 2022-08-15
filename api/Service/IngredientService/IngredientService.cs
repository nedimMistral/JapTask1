using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Service.IngredientService
{
    public class IngredientService : IIngredientService
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public IngredientService(DataContext ctx, IMapper mapper)
        {
           _ctx = ctx;
           _mapper = mapper;
        }

        public async Task<ServiceResponse<List<IngredientDto>>> Get()
        {
            var res = new ServiceResponse<List<IngredientDto>>();
            var dbIngredients = await _ctx.Ingredients.ToListAsync();

            res.Data = dbIngredients.Select(i => _mapper.Map<IngredientDto>(i)).ToList();

            return res;
        }
    }
}