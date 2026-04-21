using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.Infrastructure.Data;
using MovieShop.ApplicationCore.Entities;

namespace MovieShop.Infrastructure.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly MovieShopDbContext _dbContext;

    public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}