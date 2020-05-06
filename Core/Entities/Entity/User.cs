using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Entity
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int GroupId { get; set; }
        public List<Message> Messages { get; set; }
    }
}
