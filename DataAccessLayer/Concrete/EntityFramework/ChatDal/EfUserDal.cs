using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities.Concrete;
using Core.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using IUserDal = DataAccessLayer.Abstract.ChatDal.IUserDal;
using User = Core.Entities.Entity.User;

namespace DataAccessLayer.Concrete.EntityFramework.ChatDal
{
    public class EfUserDal : EfEntityRepositoryBase<User, ChatContext>, IUserDal
    {
        public List<User> FetchUsers()
        {
            using (var context = new ChatContext())
            {
                var data = context.Group
                    .Include(x => x.GroupMessages)
                    .Include(x => x.UserGroups).ToList();

                return context.User.ToList();
            }
        }
    }
}
