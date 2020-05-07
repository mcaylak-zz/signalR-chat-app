using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract.Chat;
using Core.Entities.Entity;
using DataAccessLayer.Abstract.ChatDal;

namespace Business.Concrete.Chat
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetUsers()
        {
            return _userDal.FetchUsers();
        }

        public User SaveUser(string userName)
        {
            _userDal.Add(new User
            {
                Username = userName
            });

            return _userDal.Get(x => x.Username == userName);
        }

        public User findUser(string userName)
        {
            return _userDal.Get(x => x.Username == userName);
        }
    }
}
