using AutoMapper;
using Business.ViewModels.Apartment;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class ApartmentProfile:Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Apartment, AddApartmentViewModel>().ReverseMap();
        }
    }
}
