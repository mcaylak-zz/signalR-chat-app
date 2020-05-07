using Core.Entities.Entity;
using Core.EntityFramework;
using DataAccessLayer.Abstract.ChatDal;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework.ChatDal
{
    public class EfGroupDal : EfEntityRepositoryBase<Group, ChatContext>, IGroupDal
    {
        
    }
}
