using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class CounterHub : Hub
    {
        static int counter = 0;
        public override Task OnConnectedAsync()
        {
            counter++;

            Clients.All.SendAsync("ReceiveCounter", counter);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            counter--;

            Clients.All.SendAsync("ReceiveCounter", counter);
            return base.OnConnectedAsync();
        }
    }
}