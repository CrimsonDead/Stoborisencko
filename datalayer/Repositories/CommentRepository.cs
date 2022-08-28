using datalayer.Context;
using datalayer.Models;

namespace datalayer.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly ApplicationContext _context;

        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Comment> Add(Comment item)
        {
            await _context.Comments.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Comment> Delete(Comment item)
        {
            _context.Comments.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Comment GetItem(Comment item)
        {
            return _context.Comments.AsParallel().FirstOrDefault(comment => comment == item);
        }

        public Comment GetItemById(int id)
        {
            return _context.Comments.AsParallel().FirstOrDefault(comment => comment.Id == id);
        }

        public IEnumerable<Comment> GetItems()
        {
            return _context.Comments.AsParallel().ToList();
        }

        public async Task<Comment> Update(Comment item)
        {
            _context.Comments.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}