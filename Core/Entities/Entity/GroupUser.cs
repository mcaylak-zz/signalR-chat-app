using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Entity
{
    public class GroupUser:IEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
