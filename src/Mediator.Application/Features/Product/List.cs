using AutoMapper;
using Mediator.Application.Interfaces.Query;

namespace Mediator.Application.Features.Product
{
    public class List
    {
        public class ProductListHandler : IQueryHandler<ProductListQuery, IEnumerable<ProductDto>>
        {
            private readonly IMapper _mapper;

            public ProductListHandler(
                IMapper mapper)
            {
                _mapper = mapper;
            }

            public Task<IEnumerable<ProductDto>> Handle(ProductListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<Domain.Entities.Product> products = new List<Domain.Entities.Product>
                {
                    new Domain.Entities.Product(1,"iPhone Pro", 1299.99M),
                    new Domain.Entities.Product(2,"iPad Pro", 999.99M),
                    new Domain.Entities.Product(3,"Airpod Pro", 179.98M),
                };

                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

                return Task.FromResult(productDtos);
            }
        }

        public class ProductListQuery { }
    }
}
