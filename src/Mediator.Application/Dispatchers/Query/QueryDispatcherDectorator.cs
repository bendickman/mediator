using Mediator.Application.Interfaces.Query;
using System.Diagnostics;

namespace Mediator.Application.Dispatchers.Query
{
    public class QueryDispatcherDectorator : IQueryDispatcher
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public QueryDispatcherDectorator(
            IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Do something before query");

            var result = _queryDispatcher
                .Dispatch<TQuery, TQueryResult>(query, cancellationToken);

            Debug.WriteLine("Do something after query");

            return result;
        }
    }
}
