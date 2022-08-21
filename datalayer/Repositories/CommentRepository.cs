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

        public Comment Add(Comment item)
        {
            _context.Comments.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Comment Delete(Comment item)
        {
            _context.Comments.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Comment GetItem(Comment item)
        {
            return _context.Comments.FirstOrDefault(comment => comment == item);
        }

        public Comment GetItemById(int id)
        {
            return _context.Comments.FirstOrDefault(comment => comment.Id == id);
        }

        public IEnumerable<Comment> GetItems()
        {
            return _context.Comments.ToList();
        }

        public Comment Update(Comment item)
        {
            _context.Comments.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}