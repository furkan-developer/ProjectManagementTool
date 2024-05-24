using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ProjectManagement.WebApp.Hubs
{
    public class CommentHub : Hub
    {
        // this method can be called by a connected clients to send comment to all clients
        // this process so performing, first js client code calls the method that is declared hub in server side and triggers related event that belongs other clients inside javascrpit code.
        // public async Task SendComment()
        // {
        //     await Clients.All.SendAsync("RecieveComment");
        // }
    }
}