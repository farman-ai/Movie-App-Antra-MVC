using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;
using MovieShop.ApplicationCore.Entities;

namespace MovieShop.MVC.Controllers;

public class UserController : Controller
{
    private readonly IPurchaseService _purchaseService;
    private readonly IUserService _userService; 

    public UserController(IPurchaseService purchaseService, IUserService userService)
    {
        _purchaseService = purchaseService;
        _userService = userService;
    }


    public async Task<IActionResult> Purchases(int userId)
    {
  
        if (userId <= 0) return RedirectToAction("Index", "Home");

        var purchases = await _purchaseService.GetUserPurchases(userId);
        return View(purchases);
    }

 
 [HttpPost]
public async Task<IActionResult> BuyMovie(int movieId, decimal price, int userId, string name, string isAdmin)
{
    if (userId == 0) userId = 1;

    var purchaseRequest = new PurchaseRequestModel
    {
        MovieId = movieId,
        UserId = userId,
        TotalPrice = price,
        PurchaseDateTime = DateTime.UtcNow,
        PurchaseNumber = Guid.NewGuid()
    };

    await _purchaseService.PurchaseMovie(purchaseRequest);
    
    // Niche ki 'var name =' wali lines hata dein kyunki wo upar parameter mein hain
    return RedirectToAction("Purchases", new { userId = userId, name = name, isAdmin = isAdmin });
}



[HttpPost]
public async Task<IActionResult> SubmitReview(int MovieId, int UserId, decimal Rating, string ReviewText, string name, string isAdmin)
{
   
    var existingReview = await _userService.GetReviewDetails(UserId, MovieId);
if (Rating >= 10) 
    {
        Rating = 9.9m; 
    }
    if (existingReview != null)
    {
  
        existingReview.Rating = Rating;
        existingReview.ReviewText = ReviewText;
        existingReview.CreatedDate = DateTime.UtcNow; // Agar date column hai toh
        await _userService.UpdateMovieReview(existingReview);
    }
    else
    {
      
        var newReview = new Review
        {
            MovieId = MovieId,
            UserId = UserId,
            Rating = Rating,
            ReviewText = ReviewText
        };
        await _userService.AddMovieReview(newReview);
    }



    TempData["SuccessMessage"] = "Review submitted successfully!";
    return RedirectToAction("Details", "Movies", new { id = MovieId, userId = UserId, name = name, isAdmin = isAdmin });
}






}