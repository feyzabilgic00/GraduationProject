using AutoMapper;
using Business.Abstract;
using Business.ViewModels.Role;
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
    public class RoleService : IRoleService
    {
        public RoleManager<Role> _roleManager;
        public UserManager<User> _userManager;
        public IRoleDal _roleDal;
        private readonly IMapper _mapper;
        public RoleService(RoleManager<Role> roleManager,UserManager<User> userManager, IRoleDal roleDal, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleDal = roleDal;
            _mapper = mapper;
        }
        public async Task<IdentityResult> AddRole(RoleViewModel roleViewModel)
        {
            _mapper.Map<Role>(roleViewModel);
            Role role = new Role { Name = roleViewModel.Name };
            return await _roleManager.CreateAsync(role);
        }

        public List<RoleViewModel> GetAll()
        {
            return _mapper.Map<List<RoleViewModel>>(_roleDal.GetAll());
        }

        public async Task<IdentityResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return await _roleManager.DeleteAsync(role);
        }
        public async Task GetById(string id)
        {
            Role role = await _roleManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> UpdateRole(RoleViewModel roleViewModel)
        {
            Role role = await _roleManager.FindByIdAsync(roleViewModel.Id);
            role.Name = roleViewModel.Name;
            return await _roleManager.UpdateAsync(role);
        }
        public IQueryable<Role> GetRoles()
        {
            return _roleManager.Roles;
        }
        public List<User> Users()
        {
            return _userManager.Users.ToList();
        }
    }
}
