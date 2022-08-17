using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using AutoMapper;


namespace api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoriesDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Recipe, AddRecipeDto>();
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<RecipeIngredient, AddRecipeIngredientDto>();
            CreateMap<Recipe, GetRecipeDetailsDto>();
        }
    }
}