using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace MyCodeFirstApproach.Common
{
    public class ReturnUrlMiddleware
    {
        private readonly RequestDelegate _next;

        public ReturnUrlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var returnUrl = context.Request.Query["ReturnUrl"].FirstOrDefault();

            if (!string.IsNullOrEmpty(returnUrl) && !context.User.Identity.IsAuthenticated)
            {
                // Người dùng chưa xác thực và có returnUrl, chuyển hướng đến returnUrl
                context.Response.Redirect(returnUrl);
                return;
            }

            await _next(context);
        }
    }
}
