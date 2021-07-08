using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmailSend:IEntity
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public virtual User Sender { get; set; }
        public DateTime SendingDate { get; set; }
        public bool HasItBeenRead { get; set; }
    }
}
