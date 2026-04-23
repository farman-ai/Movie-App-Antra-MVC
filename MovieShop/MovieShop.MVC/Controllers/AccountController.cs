
using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.MVC.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterModel model)
    {
        if (!ModelState.IsValid) return View(model);

        try
        {
            await _userService.RegisterUser(model);
            TempData["Message"] = "Registration successful. Please Login.";
            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Login(LoginModel model)
{
    if (!ModelState.IsValid) return View(model);

    var user = await _userService.ValidateUser(model.Email, model.Password);

    if (user == null)
    {
        ModelState.AddModelError("", "Invalid Email or Password");
        return View(model);
    }

    bool isAdmin = user.Email.ToLower().Contains("admin");

    // Sab kuch URL mein pass kar rahe hain
    return RedirectToAction("Index", "Home", new { 
        userId = user.Id, 
        name = user.FirstName, 
        isAdmin = isAdmin 
    });
}
}