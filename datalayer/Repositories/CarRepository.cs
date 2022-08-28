using datalayer.Context;
using datalayer.Models;

namespace datalayer.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly ApplicationContext _context;

        public CarRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Car> Add(Car item)
        {
            await _context.Cars.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Car> Delete(Car item)
        {
            _context.Cars.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Car GetItem(Car item)
        {
            return _context.Cars.AsParallel().FirstOrDefault(car => car == item);
        }

        public Car GetItemById(int id)
        {
            return _context.Cars.AsParallel().FirstOrDefault(car => car.Id == id);
        }

        public IEnumerable<Car> GetItems()
        {
            return _context.Cars.AsParallel().ToList();
        }

        public async Task<Car> Update(Car item)
        {
            _context.Cars.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}