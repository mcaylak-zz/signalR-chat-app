using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Entity;

namespace Business.Abstract.Chat
{
    public interface IUserService
    {
        List<User> GetUsers();
        User SaveUser(string userName);
        User findUser(string userName);
    }
}
