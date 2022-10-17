using Mediator.Application.Interfaces.Command;

namespace Mediator.Application.Features.Product
{
    public class Upsert
    {
        public class ProductUpsertHandler : ICommandHandler<Domain.Entities.Product, ProductUpsertResponse>
        {
            public Task<ProductUpsertResponse> Handle(Domain.Entities.Product command, CancellationToken cancellationToken)
            {
                // upsert logic here
                var result = new ProductUpsertResponse(true);

                return Task.FromResult(result);
            }
        }

        public record ProductUpsertResponse(bool isSuccess);
    }
}
