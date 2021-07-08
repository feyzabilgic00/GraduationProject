using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Vehicle:IEntity
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public string Plaque { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
    }
}
