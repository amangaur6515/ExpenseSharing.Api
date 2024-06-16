using ExpenseSharing.Api.Models;

namespace ExpenseSharing.Api.Services.Abstract
{
    public interface IAuthService
    {
        Task<UserManagerResponseViewModel> RegisterUserAsync(User userObj);
        Task<UserManagerResponseViewModel> LoginUserAsync(User userObj);
    }
}
