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
                return context.User
                    .Include(x => x.Groups)
                    .ThenInclude(x=>x.Group)
                    .ToList();
            }
        }
    }
}
