namespace datalayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItems();
        T GetItemById(int id);
        T GetItem(T item);
        T Add(T item);
        T Update(T item);
        T Delete(T item);

    }
}