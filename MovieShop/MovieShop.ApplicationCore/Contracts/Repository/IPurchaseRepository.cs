using MovieShop.ApplicationCore.Entities;

namespace MovieShop.ApplicationCore.Contracts.Repository;

public interface IPurchaseRepository : IRepository<Purchase>
{
    Task<IEnumerable<Purchase>> GetPurchasesByUser(int userId);
}
