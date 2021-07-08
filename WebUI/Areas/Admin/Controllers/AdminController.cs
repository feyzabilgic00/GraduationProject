using AutoMapper;
using Business.Abstract;
using Business.ViewModels.Role;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IRoleService _roleService = null;
        private readonly IUserService _userService = null;
        private readonly UserManager<User> _userManager = null;
        private readonly IMapper _mapper;
        public AdminController(IRoleService roleService, IUserService userService, UserManager<User> userManager, IMapper mapper)
        {
            _roleService = roleService;
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            IdentityResult result = await _roleService.AddRole(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
        public IActionResult Roles()
        {
            var result = _roleService.GetAll();
            return View(result);
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityResult result = await _roleService.Delete(id);
            return RedirectToAction("Roles", result);
        }
        public async Task<IActionResult> UpdateRole(string id)
        {
            await _roleService.GetById(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleViewModel model)
        {
            await _roleService.UpdateRole(model);
            return RedirectToAction("Roles", model);
        }
        public async Task<IActionResult> RoleAssign(string id)
        {
            TempData["userId"] = id;
            User user = await _userManager.FindByIdAsync(id);

            ViewBag.userName = user.UserName;

            IQueryable<Role> roles = _roleService.GetRoles();

            List<string> userroles = await _userManager.GetRolesAsync(user) as List<string>;

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

            foreach (var role in roles)
            {
                RoleAssignViewModel r = new RoleAssignViewModel();
                r.RoleId = role.Id;
                r.RoleName = role.Name;
                if (userroles.Contains(role.Name))
                {
                    r.Exist = true;
                }
                else
                {
                    r.Exist = false;
                }
                roleAssignViewModels.Add(r);
            }

            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> model)
        {
            User user = await _userService.GetById(TempData["userId"].ToString());
            foreach (var item in model)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Users");
        }
        public IActionResult Users()
        {
            var result = _roleService.Users();
            return View(result);
        }
    }
}
