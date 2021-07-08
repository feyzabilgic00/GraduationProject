using Business.ViewModels.User;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();
        Task<UserViewModel> GetUser(string id);
        Task<User> GetById(string id);
        Task<IdentityResult> AddUser(UserViewModel userViewModel);
        Task<IdentityResult> UpdateUser(UserViewModel userViewModel);
        Task<IdentityResult> Delete(string id);
    }
}
