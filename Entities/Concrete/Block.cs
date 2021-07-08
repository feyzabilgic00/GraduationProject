using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Block:IEntity
    {
        public int Id { get; set; }
        public string BlockName { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
