using AutoMapper;
using Business.ViewModels.Apartment;
using Business.ViewModels.User;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            //CreateMap<UserViewModel, User>();
            CreateMap<User, LoginViewModel>().ReverseMap();
           
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<User, UserViewModel>().ReverseMap();
            //});
            //config.AssertConfigurationIsValid();
        }
    }
}
