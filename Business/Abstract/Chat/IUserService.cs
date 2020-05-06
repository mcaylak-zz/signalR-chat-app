using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Entity;

namespace Business.Abstract.Chat
{
    public interface IUserService
    {
        List<User> GetUsers();
        void SaveUser(string userName);
    }
}
