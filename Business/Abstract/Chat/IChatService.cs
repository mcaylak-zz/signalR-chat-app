using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Entity;

namespace Business.Abstract.Chat
{
    public interface IChatService
    {
        List<Message> GetPrivateChatMessages(string toUser, string fromUser);
        void saveMessage(string toUser, string fromUser, string description);
        void saveGroupMessage(string groupName, string fromUser, string description);
        List<Message> GetGroupMessages(string groupName);
        List<User> GetAllUsers();
    }
}
