using AutoMapper;
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
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<CategoryResponseDTO, Category>();

            CreateMap<Country, CountryResponseDTO>();
            CreateMap<CountryResponseDTO, Country>();
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Client, ClientResponseDTO>();
            CreateMap<ClientResponseDTO, Client>();
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();

            CreateMap<Project, ProjectResponseDTO>();
            CreateMap<ProjectResponseDTO, Project>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();

            CreateMap<Emplyee, EmployeeResponseDTO>();
            CreateMap<EmployeeResponseDTO, Emplyee>();
            CreateMap<Emplyee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Emplyee>();

            CreateMap<WorkingHour, WorkingHourResponseDTO>();
            CreateMap<WorkingHourResponseDTO, WorkingHour>();
            CreateMap<WorkingHour, WorkingHourDTO>();
            CreateMap<WorkingHourDTO, WorkingHour>();
        }
    }
}
