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

        public Service Add(Service item)
        {
            _context.Services.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Service Delete(Service item)
        {
            _context.Services.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Service GetItem(Service item)
        {
            return _context.Services.FirstOrDefault(service => service == item);
        }

        public Service GetItemById(int id)
        {
            return _context.Services.FirstOrDefault(service => service.Id == id);
        }

        public IEnumerable<Service> GetItems()
        {
            return _context.Services.ToList();
        }

        public Service Update(Service item)
        {
            _context.Services.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}