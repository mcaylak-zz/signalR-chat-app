using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Entity;

namespace Business.Abstract.Chat
{
    public interface IChatService
    {
        List<Message> GetMessagesWithUsers(string toUser,string fromUser);
        List<Group> GetGroupsMessage(string groupName);
        void saveMessage(string toUser,string fromUser, string description);
        void saveGroupMessage(string groupName,string fromUser, string description);
    }
}
