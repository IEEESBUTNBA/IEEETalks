namespace IEEETalks.CQS.Infrastructure.Queries
{
    public interface IQuery<out TResult>
    {
        TResult Run();
    }

    public interface IQuery<in TParameter1, out TResult>
    {
        TResult Run(TParameter1 param);

    }

    public interface IQuery<in TParameter1, in TParameter2, out TResult>
    {
        TResult Run(TParameter1 param, TParameter2 param2);

    }
}
