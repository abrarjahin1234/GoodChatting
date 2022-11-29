using GoodChatting.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GoodChatting.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessageAsync(Message message) =>
            await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
