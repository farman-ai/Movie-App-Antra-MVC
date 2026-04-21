using System.Threading.Tasks;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IUserService
{
	Task RegisterUser(UserRegisterModel model);
}