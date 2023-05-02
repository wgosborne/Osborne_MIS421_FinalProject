using _521Final.Models;

namespace _521Final.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void MakeAdmin(string userId);

        void MakeUser(string userId);

    }
}
