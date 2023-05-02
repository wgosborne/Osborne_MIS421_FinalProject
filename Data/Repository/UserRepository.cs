using _521Final.Data.Repository.IRepository;
using _521Final.Models;

namespace _521Final.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext? _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void MakeAdmin(string userId)
        {
            //role prop on netuser table
            var userFromDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == userId);
            //userFromDb.
            _db.SaveChanges();

        }

        public void MakeUser(string userId)
        {
            throw new NotImplementedException();
        }

    }
}
