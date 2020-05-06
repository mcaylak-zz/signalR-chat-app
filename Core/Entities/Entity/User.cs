using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Entity
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
