using datalayer.Context;
using datalayer.Models;

namespace datalayer.Repositories
{
    public class OfferRepository : IRepository<Offer>
    {
        private readonly ApplicationContext _context;

        public OfferRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Offer Add(Offer item)
        {
            _context.Offers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Offer Delete(Offer item)
        {
            _context.Offers.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Offer GetItem(Offer item)
        {
            return _context.Offers.FirstOrDefault(offer => offer == item);
        }

        public Offer GetItemById(int id)
        {
            return _context.Offers.FirstOrDefault(offer => offer.Id == id);
        }

        public IEnumerable<Offer> GetItems()
        {
            return _context.Offers.ToList();
        }

        public Offer Update(Offer item)
        {
            _context.Offers.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}