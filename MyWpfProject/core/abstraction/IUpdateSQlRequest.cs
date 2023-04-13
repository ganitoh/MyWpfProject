namespace MyWpfProject.core.abstraction
{
    internal interface IUpdateSQlRequest<T> where T : class
    {
         int Id  { get; set; }

        bool UpdateRequest(T entity);
    }
}
