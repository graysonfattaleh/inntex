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
        private RoleManager<Role> roleManager;

        private ArcDBContext _context;

        private UserManager<ResearchUser> userManager;

        private IAuthorizationService authorization;

        public RoleController(RoleManager<Role> roleManager, UserManager<ResearchUser> userManager, IAuthorizationService authorizationService, ArcDBContext arcDBContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.authorization = authorizationService;
            this._context = arcDBContext;
        }

        //[AllowAnonymous]
        [Authorize(Policy = "researcherpolicy")]
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
