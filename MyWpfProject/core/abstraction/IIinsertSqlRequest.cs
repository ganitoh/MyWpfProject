namespace MyWpfProject.core.abstraction
{
    internal interface IIinsertSqlRequest<T> where T : class
    {
        bool InsertRequest(T entity);
    }
}
