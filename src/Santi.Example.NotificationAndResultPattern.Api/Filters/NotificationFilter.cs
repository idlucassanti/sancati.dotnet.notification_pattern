using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Santi.Example.Core.Utils.Notifications;
using Santi.Example.Core.Utils.Results;

namespace Santi.Example.NotificationAndResultPattern.Api.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotification)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var result = new Result<object>()
                {
                    Success = false,
                    Erros = _notificationContext.Notifications.Select(x => x.Message).ToList(),
                };

                var resultJson = JsonConvert.SerializeObject(result);
                await context.HttpContext.Response.WriteAsync(resultJson);
                return;
            }

            await next();
        }
    }
}
