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

        public Car Add(Car item)
        {
            _context.Cars.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Car Delete(Car item)
        {
            _context.Cars.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Car GetItem(Car item)
        {
            return _context.Cars.FirstOrDefault(car => car == item);
        }

        public Car GetItemById(int id)
        {
            return _context.Cars.FirstOrDefault(car => car.Id == id);
        }

        public IEnumerable<Car> GetItems()
        {
            return _context.Cars.ToList();
        }

        public Car Update(Car item)
        {
            _context.Cars.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}