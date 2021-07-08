using AutoMapper;
using Business.Abstract;
using Business.ViewModels.Apartment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService = null;
        private readonly IMapper _mapper;
        public ApartmentController(IApartmentService apartmentService,IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var result= _apartmentService.GetAll();
            return View(result);
        }
        public IActionResult AddApartment()
        {
            IEnumerable<SelectListItem> blocks = _apartmentService.GetSelectListBlocks();
            IEnumerable<SelectListItem> users= _apartmentService.GetSelectListUsers();
            ViewBag.blocks = blocks;
            ViewBag.users = users;
            return View();
        }
        [HttpPost]
        public IActionResult AddApartment(AddApartmentViewModel model)
        {
            model.BlockName = _apartmentService.GetSelectListBlocks();
            model.NameSurname = _apartmentService.GetSelectListUsers();
            _apartmentService.AddApartment(model);
            
            return RedirectToAction("Index","Apartment",model);
        }
    }
}
