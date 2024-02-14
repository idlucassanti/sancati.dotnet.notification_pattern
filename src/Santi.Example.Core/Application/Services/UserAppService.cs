using Santi.Example.Core.Application.Interfaces;
using Santi.Example.Core.Application.ViewModels;
using Santi.Example.Core.Domain.Entities;
using Santi.Example.Core.Utils.Notifications;
using Santi.Example.Core.Utils.Results;

namespace Santi.Example.Core.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly NotificationContext _notificationContext;

        public UserAppService(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public UserViewModel CreateWithException(CreateUserViewModel userViewModel)
        {
            if (string.IsNullOrEmpty(userViewModel.Name))
            {
                throw new Exception("Enter the User name!");
            }

            if (string.IsNullOrEmpty(userViewModel.Email))
            {
                throw new Exception("Enter the User e-mail!");
            }

            if (string.IsNullOrEmpty(userViewModel.PhoneNumber))
            {
                throw new Exception("Enter the User phone number!");
            }

            var user = new User(userViewModel.Name, userViewModel.Email, userViewModel.PhoneNumber);

            // INSERT DB

            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public UserViewModel CreateWithNotification(CreateUserViewModel userViewModel)
        {
            if (string.IsNullOrEmpty(userViewModel.Name))
            {
                _notificationContext.AddNotification("User", "Enter the User name!");
            }

            if (string.IsNullOrEmpty(userViewModel.Email))
            {
                _notificationContext.AddNotification("User", "Enter the User e-mail!");
            }

            if (string.IsNullOrEmpty(userViewModel.PhoneNumber))
            {
                _notificationContext.AddNotification("User", "Enter the User phone number!");
            }

            if (_notificationContext.HasNotification)
                return default; // UserViewModel => null

            var user = new User(userViewModel.Name, userViewModel.Email, userViewModel.PhoneNumber);

            // INSERT DB

            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public Result<UserViewModel> CreateWithNotificationAndResult(CreateUserViewModel userViewModel)
        {
            if (string.IsNullOrEmpty(userViewModel.Name))
            {
                _notificationContext.AddNotification("User", "Enter the User name!");
            }

            if (string.IsNullOrEmpty(userViewModel.Email))
            {
                _notificationContext.AddNotification("User", "Enter the User e-mail!");
            }

            if (string.IsNullOrEmpty(userViewModel.PhoneNumber))
            {
                _notificationContext.AddNotification("User", "Enter the User phone number!");
            }

            if (_notificationContext.HasNotification)
                return default; // UserViewModel => null

            var user = new User(userViewModel.Name, userViewModel.Email, userViewModel.PhoneNumber);

            // INSERT DB

            return new Result<UserViewModel>
            {
                Success = true,
                Data = new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                }
            };
        }
    }
}
