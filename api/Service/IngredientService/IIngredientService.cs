using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Service.IngredientService
{
    public interface IIngredientService
    {
        Task<ServiceResponse<List<IngredientDto>>> Get();
    }
}