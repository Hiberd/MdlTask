using AutoMapper;

namespace MDLTask.DataAccess
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Entities.Content, Domain.Message>().ReverseMap();

            CreateMap<Entities.Content, Domain.Models.MessageResponseGetAll>().ReverseMap();
        }
    }
}
