using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BurialSite.Models;
using BurialSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace BurialSite.Controllers
{
    /// <summary>
    /// The rolecontroller class manages all of the controls that are specific toward
    /// managing the roles of different users. Basically all of the management for user
    /// roles and permissions exist in this.
    /// SuperAdmin permissions are required for all the calls essentially.
    /// </summary>
    public class RoleController : Controller
    {
        private RoleManager<Role> roleManager;

        private ArcDBContext _context;

        private UserManager<ResearchUser> userManager;

        private readonly ILogger<RoleController> _logger;

        public RoleController(RoleManager<Role> roleManager, UserManager<ResearchUser> userManager, ArcDBContext arcDBContext, ILogger<RoleController> logger)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this._context = arcDBContext;
            this._logger = logger;
        }

        //[AllowAnonymous]
        [Authorize(Policy = "superadminpolicy")]
        public IActionResult Index()
        {
            Dictionary<ResearchUser, List<string>> researchUserRoles = new Dictionary<ResearchUser, List<string>>();
            bool isSuperUser = User.IsInRole("SuperAdmin");
            bool isResearcher = User.IsInRole("Researcher");
            List<string> currentUserRoleNames = new List<string>();

            string currentUserId = userManager.GetUserId(User);
            var roles = roleManager.Roles.ToList();
            var userRoles = _context.UserRoles.ToList();
            foreach (ResearchUser user in userManager.Users.ToList())
            {
                List<string> userRoleNames = new List<string>();
                foreach (var userRole in userRoles)
                {
                    if (user.Id == userRole.UserId)
                    {
                        userRoleNames.Add(roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault().Name);
                    }
                }
                researchUserRoles.Add(user, userRoleNames);
            }
            return View(new RoleIndexViewModel
            {
                Roles = roles,
                UserRolesDict = researchUserRoles,
                IsSuperUser = isSuperUser,
                IsResearcher = isResearcher
            }) ;
        }


        /// <summary>
        /// This is basically a useless function for now, but actually creates new 
        /// roles. This is not useful for the time being though, since there are only 2
        /// roles currently.
        /// </summary>
        /// <returns>Creates a new Role</returns>
        [Authorize(Policy = "superadminpolicy")]
        public IActionResult Create()
        {
            return View(new Role());
        }

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
        [Authorize(Policy = "superadminpolicy")]
        [HttpGet]
        public IActionResult ManageUserRoles(int UserId)
        {
            string currentUserId = userManager.GetUserId(User);
            ResearchUser user = userManager.Users.Where(u => u.Id == UserId).FirstOrDefault();
            Dictionary<string, int> userRoleNames = new Dictionary<string, int>();
            var userRoles = _context.UserRoles.ToList();
            foreach (var userRole in userRoles)
            {
                if (user.Id == userRole.UserId)
                {
                    string name = _context.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault().Name;
                    int roleid = _context.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault().Id;
                    userRoleNames.Add(name, roleid);
                }
            }
            List<Role> roles = roleManager.Roles.ToList();
            bool isEditingCurrentUser; 
            if (Int32.Parse(currentUserId) == UserId)
            {
                isEditingCurrentUser = true;
            }
            else
            {
                isEditingCurrentUser = false;
            }
            return View(new ManageUserRolesViewModel
            {
                Roles = roles,
                User = user,
                UserRoles = userRoleNames,
                IsEditingCurrentUser = isEditingCurrentUser,
            });
        }

        [Authorize(Policy = "superadminpolicy")]
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(string UserId, string roleId, bool addOrRemove, bool deleteUser)
        {

            var role = await roleManager.FindByIdAsync(roleId);
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

        [Authorize(Policy = "superadminpolicy")]
        [HttpGet]
        public IActionResult DeleteUser(int UserId)
        {
            ResearchUser user = userManager.Users.Where(u => u.Id == UserId).FirstOrDefault();
            return View(user);
        }


        [Authorize(Policy = "superadminpolicy")]
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string UserId)
        {

            string currentUserId = userManager.GetUserId(User);
            int AdminId = Int32.Parse(currentUserId);
            if (AdminId == Int32.Parse(UserId))
            {
                return LocalRedirect("/Identity/Account/Manage/DeletePersonalData");
            }

            var user = await userManager.FindByIdAsync(UserId.ToString());
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var result = await userManager.DeleteAsync(user);
            var userId = await userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            //await signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' was deleted by User with ID '{AdminId}'.", UserId, AdminId);

            return Redirect("/Role/Index");
        }

    }
}
