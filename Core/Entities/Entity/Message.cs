using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Entity
{
    public class Message:IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FromName { get; set; }
        public string GroupName { get; set; }
        public string ToName { get; set; }
        public DateTime Date { get; set; }
    }
}
