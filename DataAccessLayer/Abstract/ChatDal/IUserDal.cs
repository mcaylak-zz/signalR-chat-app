using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccessLayer;
using Core.Entities.Entity;

namespace DataAccessLayer.Abstract.ChatDal
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<User> FetchUsers();
    }
}
