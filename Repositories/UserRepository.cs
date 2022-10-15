using Interfaces.Repositories;
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
        public async Task<User> GetUserAsync(Guid key) => await _db.Users.FindAsync(key);
        public Task InsertUser(User user)
        {
            _db.Users.Add(user);
            return _db.SaveChangesAsync();
        }
    }
}
