namespace MovieShop.ApplicationCore.Models;

public class PurchaseRequestModel
{
    public int MovieId { get; set; }
    public decimal TotalPrice { get; set; }
}