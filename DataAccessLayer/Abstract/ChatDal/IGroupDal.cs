using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccessLayer;
using Core.Entities.Entity;

namespace DataAccessLayer.Abstract.ChatDal
{
    public interface IGroupDal:IEntityRepository<Group>
    {
        List<Group> GroupMessages(string groupName);
    }
}
