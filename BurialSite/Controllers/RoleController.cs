using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BurialSite.Models;
using BurialSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurialSite.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<Role> roleManager;

        UserManager<ResearchUser> userManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<ResearchUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        //[AllowAnonymous]
        [Authorize(Policy = "researcherpolicy")]
        public IActionResult Index()
        {

            var roles = roleManager.Roles.ToList();
            var users = userManager.Users.ToList();
            return View(new RoleIndexViewModel
            {
                Roles = roles,
                Users = users
            });
        }

        //[AllowAnonymous]
        [Authorize(Policy = "superadminpolicy")]
        public IActionResult Create()
        {
            return View(new Role());
        }

        //[AllowAnonymous]
        [Authorize(Policy = "superadminpolicy")]
        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This is to manage a single user's roles
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        [Authorize(Policy = "superadminpolicy")]
        [HttpGet]
        public IActionResult ManageUserRoles(int UserId)
        {
            ResearchUser user = userManager.Users.Where(u => u.Id == UserId).FirstOrDefault();

            List<Role> roles = roleManager.Roles.ToList();
            return View(new ManageUserRolesViewModel
            {
                Roles = roles,
                User = user
            });
        }

        //////
        //[AllowAnonymous]
        [Authorize(Policy = "superadminpolicy")]
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(string UserId, string roleId, bool addOrRemove)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            //await roleManager.CreateAsync(role);
            var user = await userManager.FindByIdAsync(UserId);
            if (addOrRemove)
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, role.Name);
            }
            else if (!addOrRemove)
            {
                IdentityResult result = await userManager.RemoveFromRoleAsync(user, role.Name);
            }
            else
            {
                Console.Out.WriteLine("what? not sure of the input on that one...");
            }

            return RedirectToAction("Index");

        }

    }
}
