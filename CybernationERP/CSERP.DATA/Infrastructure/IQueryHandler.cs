namespace CSERP.DATA.Infrastructure
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Query(TQuery query);
    }
}
