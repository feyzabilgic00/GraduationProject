using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BulkBorrowing:IEntity
    {
        public int Id { get; set; }
        public virtual ICollection<Debit> Debits { get; set; }
        public DateTime DebtDate { get; set; }
        public virtual DistributionType DistributionType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}
