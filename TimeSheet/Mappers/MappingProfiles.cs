using AutoMapper;
using System.Collections.Generic;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;

namespace TimeSheet.WebAPI.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();
            CreateMap<UpdateCountryDTO, Country>();
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<CategoryResponseDTO, Category>();
        }
    }
}
