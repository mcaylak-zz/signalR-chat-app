using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Entity
{
    public class GroupMessage:IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FromName { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
    }
}
