using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.Infrastructure.Data;
using MovieShop.ApplicationCore.Entities;

namespace MovieShop.Infrastructure.Repository;

public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Purchase>> GetPurchasesByUser(int userId)
    {
        return await _dbContext.Purchases
            .Include(p => p.Movie)
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.PurchaseDateTime)
            .ToListAsync();
    }
}