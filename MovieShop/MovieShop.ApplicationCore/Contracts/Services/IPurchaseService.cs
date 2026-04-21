using MovieShop.ApplicationCore.Models;

namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IPurchaseService
{
    Task SavePurchase(PurchaseModel model);
    Task<IEnumerable<PurchaseModel>> GetUserPurchases(int userId);
}