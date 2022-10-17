using Mediator.Application.Interfaces.Query;

namespace Mediator.Application.Features.Product
{
    public class List
    {
        public class ProductListHandler : IQueryHandler<ProductListQuery, IEnumerable<Domain.Entities.Product>>
        {
            public Task<IEnumerable<Domain.Entities.Product>> Handle(ProductListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<Domain.Entities.Product> products = new List<Domain.Entities.Product>
                {
                    new Domain.Entities.Product(1,"iPhone Pro", 1299.99M),
                    new Domain.Entities.Product(2,"iPad Pro", 999.99M),
                    new Domain.Entities.Product(3,"Airpod Pro", 179.98M),
                };

                return Task.FromResult(products);
            }
        }

        public class ProductListQuery { }
    }
}
