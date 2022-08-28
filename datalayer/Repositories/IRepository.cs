namespace datalayer.Repositories
{
    public interface IRepository<TItem> where TItem : class
    {
        IEnumerable<TItem> GetItems();
        TItem GetItemById(int id);
        TItem GetItem(TItem item);
        Task<TItem> Add(TItem item);
        Task<TItem> Update(TItem item);
        Task<TItem> Delete(TItem item);

    }
}