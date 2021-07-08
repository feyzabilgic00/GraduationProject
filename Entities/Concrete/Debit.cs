using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Debit:IEntity
    {
        public int Id { get; set; }
        public virtual DebitType DebitType { get; set; }
        public virtual User User { get; set; }
        public virtual Apartment Apartment { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string DocumentNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime DelayStartDate { get; set; }
    }
}
