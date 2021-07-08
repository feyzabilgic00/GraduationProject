using Business.ViewModels.Apartment;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApartmentService
    {
        List<AddApartmentViewModel> GetAll();
        List<SelectListItem> GetSelectListBlocks();
        List<SelectListItem> GetSelectListUsers();
        void AddApartment(AddApartmentViewModel addApartmentViewModel);
        void AddApartment(Apartment apartment);
        AddApartmentViewModel UpdateApartment(AddApartmentViewModel addApartmentViewModel);
        AddApartmentViewModel DeleteApartment(AddApartmentViewModel addApartmentViewModel);
    }
}
