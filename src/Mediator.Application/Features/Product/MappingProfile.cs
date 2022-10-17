using AutoMapper;

namespace Mediator.Application.Features.Product
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
        }
    }
}
