using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.Chat;
using Core.Entities.Entity;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.SignalR
{
    public class ChatHub : Hub
    { 
        private static List<ConnectedUser> _connectedUsers = new List<ConnectedUser>();
        private IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public override Task OnConnectedAsync()
        {
            var username = Context.GetHttpContext().Request.Query["username"];

            var status = _connectedUsers.FirstOrDefault(x => x.Username == username);

            var data = Context.UserIdentifier;

            if (status == null)
            {
                _connectedUsers.Add(new ConnectedUser
                {
                    ConnId = Context.ConnectionId,
                    Username = username
                });

            }

            return base.OnConnectedAsync();
        }

        public void ChatBroadCast(string message)
        {
            Clients.All.SendAsync("receiveBroadCast", message);
        }

        public void PrivateChat(string toUser,string fromUser,string message)
        {
            _chatService.saveMessage(toUser,fromUser,message);
            _connectedUsers.ForEach(val =>
            {
                if (val.Username == fromUser)
                    Clients.Clients(val.ConnId).SendAsync("receiveMessage", message, fromUser);

            });
        }

        public void JoinRoom(string roomName)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            var userName = _connectedUsers.Find(x => x.ConnId == Context.ConnectionId).Username; 
            Clients.Group(roomName).SendAsync("ReceiveGroupMessage",  userName + " Joined");
        }

        public void LeaveRoom(string roomName)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            var userName = _connectedUsers.Find(x => x.ConnId == Context.ConnectionId).Username;
            Clients.Group(roomName).SendAsync("ReceiveGroupMessage", userName + " Leave");
        }

        public void SendMessageToRoom(string fromName,string roomName,string message)
        {
            /*Save group message*/
            Clients.Group(roomName).SendAsync("ReceiveGroupMessage", message); // send group clients
        }

        public List<ConnectedUser> GetAllActiveConnections()
        {
            return _connectedUsers;
        }
    }

    public class ConnectedUser
    {
        public string Username { get; set; }
        public string ConnId { get; set; }
    }
}
