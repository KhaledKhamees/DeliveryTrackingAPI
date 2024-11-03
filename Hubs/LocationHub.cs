using DeliveryTrackingAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace DeliveryTrackingAPI.Hubs
{
    public class LocationHub : Hub
    {
        public async Task SendLocationUpdate(Location location)
        {
            await Clients.All.SendAsync("ReceiveLocationUpdate", location);
        }
    }
}
