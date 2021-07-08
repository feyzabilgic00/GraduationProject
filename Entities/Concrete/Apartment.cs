using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Apartment:IEntity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Block")]
        public int BlockId { get; set; }
        public virtual Block Block { get; set; }        
        public bool Status { get; set; }
        public string Type { get; set; }
        public string FloorLocation { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
