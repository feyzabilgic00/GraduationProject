using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ApartmentDetailDto:IDto
    {
        public int Id { get; set; }
        //public int BlockId { get; set; }
        public string BlockName { get; set; }
        //public string UserId { get; set; }
        public string NameSurname { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public string FloorLocation { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
