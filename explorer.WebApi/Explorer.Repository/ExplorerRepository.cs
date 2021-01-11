using System.Linq;
using System.Threading.Tasks;
using Explorer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Repository
{
    public class ExplorerRepository : IExplorerRepository
    {

        private readonly ExplorerContext _context;

        public ExplorerRepository(ExplorerContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Comment[]> GetAllCommentsAsync()
        {
            IQueryable<Comment> query = _context.Comments.Include(c => c.Id).Include(c => c.Text).OrderBy(c => c.DatePublish);

            return await query.ToArrayAsync();

        }

        public async Task<Location[]> GetAllLocationsAsync()
        {
            IQueryable<Location> query = _context.Locations.OrderBy(l => l.Name);

            return await query.ToArrayAsync();

        }

        public async Task<User[]> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users.Include(l => l.Name).Include(l => l.email).Include(l => l.Adress).OrderBy(l => l.Name);

            return await query.ToArrayAsync();
        }

        public async Task<Comment> GetCommentById(int CommentId)
        {
            IQueryable<Comment> query = _context.Comments.Include(c => c.Id).Include(c => c.Text).Where(c => c.Id == CommentId).OrderBy(c => c.DatePublish);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Location> GetLocationById(int LocationId)
        {
            IQueryable<Location> query = _context.Locations.Where(l => l.Id == LocationId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int UserId)
        {
            IQueryable<User> query = _context.Users.Where(u => u.Id == UserId);

            return await query.FirstOrDefaultAsync();
        }


    }
}