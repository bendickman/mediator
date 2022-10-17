using Mediator.Application.Interfaces.Query;

namespace Mediator.Infrastructure.Features.Product
{
    public class List
    {
        public class ProductHandler : IQueryHandler<ProductQuery, IEnumerable<Product>>
        {
            public Task<IEnumerable<Product>> Handle(ProductQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<Product> products = new List<Product>
                {
                    new Product(1,"iPhone Pro", 1299.99M),
                    new Product(2,"iPad Pro", 999.99M),
                    new Product(3,"Airpod Pro", 179.98M),
                };

                return Task.FromResult(products);
            }
        }

        public class ProductQuery { }

        public record Product(int id, string name, decimal price);
    }
}
