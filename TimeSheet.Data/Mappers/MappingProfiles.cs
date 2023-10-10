using AutoMapper;


namespace TimeSheet.Data.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Models.Category, Data.Entities.Category>();
            CreateMap<Data.Entities.Category, Core.Models.Category>();
            CreateMap<Core.Models.Country, Data.Entities.Country>();
            CreateMap<Data.Entities.Country, Core.Models.Country>();
        }
    }
}
