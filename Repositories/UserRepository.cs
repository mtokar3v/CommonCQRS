using Constants;
using Interfaces.Repositories;
using System.Data.Entity.Core;

using RootDb;
using RootDb.Entities;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RootDbContext _db;

        public UserRepository(RootDbContext db)
        {
            _db = db;
        }

        public IQueryable<User> GetUsers() => _db.Users.Select(u => u);
        public async Task<User> GetUserAsync(Guid userId) => await _db.Users.FindAsync(userId);
        
        public Task InsertUser(User user)
        {
            _db.Users.Add(user);
            return _db.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await GetUserAsync(userId);
            if (user is null) throw new ObjectNotFoundException(Failed.ToFindUser(userId));

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> UpdateUserEmailAsync(Guid userId, string email)
        {
            var user = await GetUserAsync(userId);
            if (user is null) throw new ObjectNotFoundException(Failed.ToFindUser(userId));

            user.Email = email;
            await _db.SaveChangesAsync();

            return user;
        }
    }
}
