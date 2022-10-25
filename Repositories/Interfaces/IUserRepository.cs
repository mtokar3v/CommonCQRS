using RootDb.Entities;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        Task<User> GetUserAsync(Guid key);

        Task InsertUser(User user);

        Task DeleteUserAsync(Guid key);

        Task<User> UpdateUserEmailAsync(Guid userId, string email);
    }
}