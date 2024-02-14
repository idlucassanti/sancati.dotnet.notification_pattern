using Microsoft.Extensions.DependencyInjection;
using Santi.Example.Core.Application.Interfaces;
using Santi.Example.Core.Application.Services;
using Santi.Example.Core.Utils.Notifications;

namespace Santi.Example.Core.IoC
{
    public static class DependecyInjection
    {
        public static void AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<NotificationContext>();

            serviceCollection.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
