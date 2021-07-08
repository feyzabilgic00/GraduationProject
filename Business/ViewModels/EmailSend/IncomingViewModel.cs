using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.EmailSend
{
    public class IncomingViewModel:ViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Sender { get; set; }
        public DateTime SendingDate { get; set; }
        public bool HasItBeenRead { get; set; }
    }
}
