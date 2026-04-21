using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class UserController : Controller
{
    private readonly IPurchaseService _purchaseService;

    public UserController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public async Task<IActionResult> Purchases()
    {
        var userId = 1;
        var purchases = await _purchaseService.GetUserPurchases(userId);
        return View(purchases);
    }
}