using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Kinder_Backend.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendMessageAsync(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
