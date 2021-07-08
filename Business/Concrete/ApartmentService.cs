using AutoMapper;
using Business.Abstract;
using Business.ViewModels.Apartment;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ApartmentService : IApartmentService
    {
        public IApartmentDal _apartmentDal;
        private readonly IMapper _mapper;
        public ApartmentService(IApartmentDal apartmentDal,IMapper mapper)
        {
            _apartmentDal = apartmentDal;
            _mapper = mapper;
        }
        public void AddApartment(AddApartmentViewModel addApartmentViewModel)
        {
            _apartmentDal.Add(_mapper.Map<Apartment>(addApartmentViewModel));
        }
        public AddApartmentViewModel DeleteApartment(AddApartmentViewModel addApartmentViewModel)
        {
            throw new NotImplementedException();
        }

        public List<AddApartmentViewModel> GetAll()
        {
            return _mapper.Map<List<AddApartmentViewModel>>(_apartmentDal.GetAll());
        }

        public List<SelectListItem> GetSelectListBlocks()
        {
            return _apartmentDal.GetSelectListBlocks();
        }

        public List<SelectListItem> GetSelectListUsers()
        {
            return _apartmentDal.GetSelectListUsers();
        }

        public AddApartmentViewModel UpdateApartment(AddApartmentViewModel addApartmentViewModel)
        {
            throw new NotImplementedException();
        }

        public void AddApartment(Apartment apartment)
        {
            _apartmentDal.Add(apartment);
        }
    }
}
