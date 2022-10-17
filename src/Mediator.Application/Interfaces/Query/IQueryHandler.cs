namespace Mediator.Application.Interfaces.Query
{
    public interface IQueryHandler<in TQuery, TQueryResult>
    {
        Task<TQueryResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
