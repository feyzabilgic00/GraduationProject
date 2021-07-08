using Business.ViewModels.Role;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        List<RoleViewModel> GetAll();
        List<User> Users();
        Task<IdentityResult> AddRole(RoleViewModel roleViewModel);
        Task<IdentityResult> Delete(string id);
        Task GetById(string id);
        IQueryable<Role> GetRoles();
        Task<IdentityResult> UpdateRole(RoleViewModel roleViewModel);
    }
}
