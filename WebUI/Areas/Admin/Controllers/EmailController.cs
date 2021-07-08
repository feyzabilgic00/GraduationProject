using AutoMapper;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSendService _emailSendService = null;
        private readonly IMapper _mapper;
        public EmailController(IEmailSendService emailSendService, IMapper mapper)
        {
            _emailSendService = emailSendService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IncomingEmail()
        {
            return View(_emailSendService.GetAll());
        }
        public IActionResult NewEmail()
        {
            return View();
        }
    }
}
