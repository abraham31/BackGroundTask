using Microsoft.AspNetCore.SignalR;

namespace BackGroundService.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotificationToAll(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
