using AutoMapper;
using Business.Abstract;
using Business.ViewModels.User;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {        
        public IUserDal _userDal;
        public UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        public UserService(IUserDal userDal,IMapper mapper, UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUser(UserViewModel userViewModel)
        {
            _mapper.Map<User>(userViewModel);
            User user = new User{UserName=userViewModel.Email,NameSurname = userViewModel.NameSurname,TcNo=userViewModel.TcNo, Email = userViewModel.Email, PhoneNumber = userViewModel.PhoneNumber,PlateNumber=userViewModel.PlateNumber};
            return await _userManager.CreateAsync(user);
        }

        public List<UserViewModel> GetAll()
        {
            return _mapper.Map<List<UserViewModel>>(_userDal.GetAll());
        }
        public async Task<IdentityResult> UpdateUser(UserViewModel userViewModel)
        {
            User user = await _userManager.FindByEmailAsync(userViewModel.Email);

            user.NameSurname = userViewModel.NameSurname;
            user.TcNo = userViewModel.TcNo;
            user.PhoneNumber = userViewModel.PhoneNumber;
            user.Email = userViewModel.Email;
            user.UserName = userViewModel.Email;
            user.PlateNumber = userViewModel.PlateNumber;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<UserViewModel> GetUser(string id)
        {
            var map= _mapper.Map<User,UserViewModel>(await _userManager.FindByIdAsync(id));
            return map;
        }
        public async Task<IdentityResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.DeleteAsync(user);
        }

        public async Task<User> GetById(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            return user;
        }
    }
}
