using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract.Chat;
using Core.Entities.Entity;
using DataAccessLayer.Abstract.ChatDal;

namespace Business.Concrete.Chat
{
    public class ChatManager:IChatService
    {
        private IMessageDal _messageDal;
        private IGroupDal _groupDal;

        public ChatManager(IMessageDal messageDal, IGroupDal groupDal)
        {
            _messageDal = messageDal;
            _groupDal = groupDal;
        }

        public List<Message> GetMessagesWithUsers(string toUser, string fromUser)
        {
            return _messageDal.GetMessagesWithUsers(toUser, fromUser);
        }

        public List<Group> GetGroupsMessage(string groupName)
        {
            return _groupDal.GroupMessages(groupName);
        }

        public void saveMessage(string toUser, string fromUser,string description)
        {
            _messageDal.Add(new Message
            {
                Date = DateTime.Now,
                Description = description,
                FromName = fromUser,
                ToName = toUser
            });
        }

        public void saveGroupMessage(string groupName, string fromUser, string description)
        {
            var group = _groupDal.Get(x => x.Name == groupName);

            @group?.GroupMessages.Add(new GroupMessage
            {
                Date = DateTime.Now,
                FromName = fromUser,
                Description = description
            });
        }
    }
}
