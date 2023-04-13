namespace MyWpfProject.core.abstraction
{
    internal interface IDeleteSqlRequest<T> 
    {
        bool DeleteRequest(T primaryKey);
    }
}
