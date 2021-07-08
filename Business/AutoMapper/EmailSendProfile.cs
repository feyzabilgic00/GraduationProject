using AutoMapper;
using Business.ViewModels.EmailSend;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class EmailSendProfile:Profile
    {
        public EmailSendProfile()
        {
            CreateMap<EmailSend, IncomingViewModel>().ReverseMap();
        }
    }
}
