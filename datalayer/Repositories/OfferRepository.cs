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

        public async Task<Offer> Add(Offer item)
        {
            await _context.Offers.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Offer> Delete(Offer item)
        {
            _context.Offers.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Offer GetItem(Offer item)
        {
            return _context.Offers.AsParallel().FirstOrDefault(offer => offer == item);
        }

        public Offer GetItemById(int id)
        {
            return _context.Offers.AsParallel().FirstOrDefault(offer => offer.Id == id);
        }

        public IEnumerable<Offer> GetItems()
        {
            return _context.Offers.AsParallel().ToList();
        }

        public async Task<Offer> Update(Offer item)
        {
            _context.Offers.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}