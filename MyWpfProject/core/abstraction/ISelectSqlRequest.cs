namespace MyWpfProject.core.abstraction
{
    internal interface ISelectSqlRequest<T>
    {
        T SelectRequest();
    }
}
