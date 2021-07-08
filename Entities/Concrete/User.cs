using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Concrete
{
    public class User:IdentityUser,IEntity
    {
        //public virtual Block Block { get; set; }
        public virtual Apartment Apartment { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public string NameSurname { get; set; }
        public string TcNo { get; set; }
        public string PlateNumber { get; set; }
    }
}
