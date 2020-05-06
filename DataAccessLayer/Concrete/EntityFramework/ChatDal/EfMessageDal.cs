using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities.Entity;
using Core.EntityFramework;
using DataAccessLayer.Abstract.ChatDal;
using DataAccessLayer.Concrete.EntityFramework.Contexts;

namespace DataAccessLayer.Concrete.EntityFramework.ChatDal
{
    public class EfMessageDal:EfEntityRepositoryBase<Message,ChatContext> , IMessageDal
    {
        public List<Message> GetMessagesWithUsers(string toUser, string fromUser)
        {
            using (var context = new ChatContext())
            {
                return context.Message
                    .Where(x => x.ToName == toUser && x.FromName == fromUser)
                    ?.OrderBy(x => x.Date).ToList();
            }
        }
    }
}
