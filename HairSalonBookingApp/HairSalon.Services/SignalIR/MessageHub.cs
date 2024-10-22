using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace HairSalon.Services.SignalIR
{
    public class MessageHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            // Make sure the Microsoft.AspNetCore.Http namespace is included
            var httpContext = Context.GetHttpContext();

            if (httpContext != null)
            {
                // You can now access the HTTP context properties, such as User or Headers
                string userId = httpContext.User.Identity.Name ?? "Anonymous";
                // Additional logic can go here
            }

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
