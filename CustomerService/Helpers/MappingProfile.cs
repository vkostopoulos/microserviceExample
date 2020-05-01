using AutoMapper;
using BOL;
using DTO;

namespace CustomerService.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<customerDto, Customer>();
            CreateMap<Customer, customerDto>();
        }
    }

}
