using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Entities;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.Infrastructure.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseService(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task SavePurchase(PurchaseModel model)
    {
        var purchase = new Purchase
        {
            UserId = model.UserId,
            MovieId = model.MovieId,
            TotalPrice = model.TotalPrice,
            PurchaseDateTime = model.PurchaseDateTime
        };

        await _purchaseRepository.Add(purchase);
    }

   public async Task<IEnumerable<PurchaseModel>> GetUserPurchases(int userId)
{
    var purchases = await _purchaseRepository.GetPurchasesByUser(userId);

    return purchases.Select(p => new PurchaseModel
    {
        UserId = p.UserId,
        MovieId = p.MovieId,
        Title = p.Movie.Title,
        PosterUrl = p.Movie.PosterUrl,
        PurchaseNumber = p.PurchaseNumber,
        TotalPrice = p.TotalPrice,
        PurchaseDateTime = p.PurchaseDateTime
    });
}
}