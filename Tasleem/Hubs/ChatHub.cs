using Microsoft.AspNetCore.SignalR;

namespace TasleemDelivery.Hubs
{
    public sealed class ChatHub:Hub
    {
        public async Task SendMessage(string receiverId, string message)
        {
           
            await Clients.Users(new[] { Context.ConnectionId, receiverId }).SendAsync("ReceiveMessage", message);
        }
    }
}
