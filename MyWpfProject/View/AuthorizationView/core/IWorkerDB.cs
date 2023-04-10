namespace MyWpfProject.View.AuthorizationView.core
{
    public interface IWorkerDB<T> where T : class
    {
         T SelectRequest();
        T UpdateRequest();
        void InsertRequest();
        void DeleteRequest();
    }
}
