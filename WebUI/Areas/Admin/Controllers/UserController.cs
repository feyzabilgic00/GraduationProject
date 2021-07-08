using AutoMapper;
using Business.Abstract;
using Business.ViewModels.User;
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
    public class UserController : Controller
    {
        private readonly IUserService _userService = null;        
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var result = _userService.GetAll();
            return View(result);
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _userService.AddUser(userViewModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(userViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> BringUser(string id)
        {
            var result = await _userService.GetUser(id);
            return View("BringUser", result);
        }
        public IActionResult EditUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result =await _userService.UpdateUser(userViewModel);

                if (result.Succeeded)
                {
                    ViewBag.success = "true";
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    //AddModelError(result);
                }
            }
            return RedirectToAction("Index","Admin",userViewModel);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _userService.Delete(id);

                if (result.Succeeded)
                {
                    ViewBag.success = "true";
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    //AddModelError(result);
                }
            }
            return RedirectToAction("Index", "Admin");
        }
        [Authorize(Roles ="manager")]
        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult AccesDenied()
        {
            return View();
        }
    }
}
