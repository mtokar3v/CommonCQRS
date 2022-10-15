using RootDb.Entities;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        Task<User> GetUserAsync(Guid key);
        Task InsertUser(User user);
    }
}