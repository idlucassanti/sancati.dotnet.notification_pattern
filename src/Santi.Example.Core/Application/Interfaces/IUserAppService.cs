using Santi.Example.Core.Application.ViewModels;
using Santi.Example.Core.Utils.Results;

namespace Santi.Example.Core.Application.Interfaces
{
    public interface IUserAppService
    {
        public UserViewModel CreateWithException(CreateUserViewModel userViewModel);
        public UserViewModel CreateWithNotification(CreateUserViewModel userViewModel);
        public Result<UserViewModel> CreateWithNotificationAndResult(CreateUserViewModel userViewModel);
    }
}
