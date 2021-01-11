using System.Threading.Tasks;
using Explorer.Domain;

namespace Explorer.Repository
{
    public interface IExplorerRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Users
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserById(int UserId);

        //Locations
        Task<Location[]> GetAllLocationsAsync();
        Task<Location> GetLocationById(int LocationId);

        //Comments
        Task<Comment[]> GetAllCommentsAsync();
        Task<Comment> GetCommentById(int CommentId);

    }
}