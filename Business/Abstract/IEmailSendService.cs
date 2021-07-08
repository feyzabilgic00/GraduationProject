using Business.ViewModels.EmailSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmailSendService
    {
        List<IncomingViewModel> GetAll();
    }
}
