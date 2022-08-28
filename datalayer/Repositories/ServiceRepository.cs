using datalayer.Context;
using datalayer.Models;

namespace datalayer.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly ApplicationContext _context;

        public ServiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Service> AddAsync(Service item)
        {
            await _context.Services.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Service> DeleteAsync(Service item)
        {
            _context.Services.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Service GetItem(Service item)
        {
            return _context.Services.AsParallel().FirstOrDefault(service => service == item);
        }

        public Service GetItemById(int id)
        {
            return _context.Services.AsParallel().FirstOrDefault(service => service.Id == id);
        }

        public IEnumerable<Service> GetItems()
        {
            return _context.Services.AsParallel().ToList();
        }

        public async Task<Service> UpdateAsync(Service item)
        {
            _context.Services.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}