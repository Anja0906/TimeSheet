using AutoMapper;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;

namespace TimeSheet.WebAPI.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryResponseDTO>().ReverseMap();

            CreateMap<Country, CountryResponseDTO>().ReverseMap();
            CreateMap<CountryDTO, Country>().ReverseMap();

            CreateMap<Client, ClientResponseDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();

            CreateMap<Project, ProjectResponseDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();

            CreateMap<Emplyee, EmployeeResponseDTO>().ReverseMap();
            CreateMap<Emplyee, EmployeeDTO>().ReverseMap();

            CreateMap<WorkingHour, WorkingHourResponseDTO>().ReverseMap();
            CreateMap<WorkingHour, WorkingHourDTO>().ReverseMap();

            CreateMap<CalendarItem, CalendarItemDTO>().ReverseMap();

            CreateMap<CalendarResponse, CalendarResponseDTO>().ReverseMap();
            CreateMap<ReportResponse, ReportResponseMapDTO>().ReverseMap();
            
            CreateMap<LoginRequest, LoginRequestDTO>().ReverseMap();
        }
    }
}
