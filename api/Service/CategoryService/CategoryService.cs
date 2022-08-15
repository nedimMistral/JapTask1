using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public CategoryService(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CategoriesDto>>> Get(int n)
        {
            var res = new ServiceResponse<List<CategoriesDto>>();
            var dbCategories = new List<Category>();

            if(n != 0)
            {
                dbCategories = await _ctx.Categories.OrderByDescending(x => x.CreatedAt).Take(n).ToListAsync();
            }
            else
            {
                dbCategories = await _ctx.Categories.OrderByDescending(x => x.CreatedAt).ToListAsync();
            }

            res.Data = dbCategories.Select(x => _mapper.Map<CategoriesDto>(x)).ToList();

            return res;
        }
    }
}