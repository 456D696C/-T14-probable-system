namespace Simple.Query
{
    //see:https://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=92

    public interface IQuery<TResult> { }
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> { TResult Handle(TQuery query); }
    public interface IQueryProcessor { TResult Process<TResult>(IQuery<TResult> query); }
}
