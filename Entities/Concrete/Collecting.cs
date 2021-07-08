using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Collecting:IEntity
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Block Block { get; set; }
        public DateTime Date { get; set; }
        public string DocumentNumber { get; set; }
        public string Safe { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}
