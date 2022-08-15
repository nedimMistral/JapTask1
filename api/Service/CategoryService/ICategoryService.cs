using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoriesDto>>> Get(int n);
    }
}