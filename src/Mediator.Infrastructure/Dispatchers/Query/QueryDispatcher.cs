using Mediator.Application.Interfaces.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Infrastructure.Dispatchers.Query
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery,TQueryResult>>();

            return handler.Handle(query, cancellationToken);
        }
    }
}
