using MovieShop.ApplicationCore.Entities;

namespace MovieShop.ApplicationCore.Contracts.Repository;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmail(string email);
}