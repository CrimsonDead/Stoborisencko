namespace datalayer.Repositories
{
    public interface IRepository<TItem> where TItem : class
    {
        IEnumerable<TItem> GetItems();
        TItem GetItemById(int id);
        TItem GetItem(TItem item);
        Task<TItem> AddAsync(TItem item);
        Task<TItem> UpdateAsync(TItem item);
        Task<TItem> DeleteAsync(TItem item);

    }
}