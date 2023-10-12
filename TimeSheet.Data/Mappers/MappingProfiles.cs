using AutoMapper;


namespace TimeSheet.Data.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Models.Category, Data.Entities.Category>().ReverseMap();

            CreateMap<Core.Models.Country, Data.Entities.Country>().ReverseMap();

            CreateMap<Core.Models.Client, Data.Entities.Client>().ReverseMap();

            CreateMap<Core.Models.Emplyee, Data.Entities.Emplyee>().ReverseMap();

            CreateMap<Core.Models.Project, Data.Entities.Project>().ReverseMap();

            CreateMap<Core.Models.WorkingHour, Data.Entities.WorkingHour>().ReverseMap();
        }
    }
}
