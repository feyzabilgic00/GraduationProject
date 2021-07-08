using AutoMapper;
using Business.Abstract;
using Business.ViewModels.EmailSend;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmailSendService:IEmailSendService
    {
        public IEmailSendDal _emailSendDal;
        private readonly IMapper _mapper;
        public EmailSendService(IEmailSendDal emailSendDal,IMapper mapper)
        {
            _emailSendDal = emailSendDal;
            _mapper = mapper;
        }

        public List<IncomingViewModel> GetAll()
        {
            return _mapper.Map<List<IncomingViewModel>>(_emailSendDal.GetAll());
        }
    }
}
