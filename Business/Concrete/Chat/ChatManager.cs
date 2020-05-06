using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract.Chat;
using Core.Entities.Entity;
using DataAccessLayer.Abstract.ChatDal;

namespace Business.Concrete.Chat
{
    public class ChatManager:IChatService
    {
        private IMessageDal _messageDal;
        private IUserService _userService;

        public ChatManager(IMessageDal messageDal, IUserService userService)
        {
            _messageDal = messageDal;
            _userService = userService;
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
            _messageDal.Add(new Message
            {
                Date = DateTime.Now,
                Description = description,
                FromName = fromUser,
                GroupName = groupName
            });
        }

        public List<Message> GetGroupMessages(string groupName)
        {
            return _messageDal.GetList(x => x.GroupName == groupName)
                    .OrderBy(x => x.Date).ToList();
        }

        public List<Message> GetPrivateChatMessages(string toUser, string fromUser)
        {
            return _messageDal.GetList(x => x.ToName == toUser && x.FromName == fromUser && x.GroupName == null)
                    .OrderBy(x => x.Date).ToList();
        }

        public List<User> GetAllUsers()
        {
            return _userService.GetUsers();
        }
    }
}
