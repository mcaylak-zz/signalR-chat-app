using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities.Entity;
using Core.EntityFramework;
using DataAccessLayer.Abstract.ChatDal;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework.ChatDal
{
    public class EfGroupDal: EfEntityRepositoryBase<Group, ChatContext>, IGroupDal
    {
        public List<Group> GroupMessages(string groupName)
        {
            using (var context = new ChatContext())
            {
                return context.Group.Include(x => x.GroupMessages)
                    .Where(x=>x.Name == groupName).ToList();
            }
        }
    }
}
