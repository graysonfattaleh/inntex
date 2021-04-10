using BurialSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurialSite.Controllers
{
    public class AccountController : Controller
    {

       private UserManager<ResearchUser> UserMgr { get; }
       private SignInManager<ResearchUser> SignInMgr { get; }
       public AccountController(UserManager<ResearchUser> userManager, 
           SignInManager<ResearchUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("/Account/Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(Role researcher)
        {
            try
            {
                ViewBag.Message = "User already registered";

                ResearchUser user = await UserMgr.FindByNameAsync("TestUser");
                if (user == null)
                {
                    user = new ResearchUser
                    {
                        UserName = "TestUser",
                        Email = "maxistache@gmail.com",
                        FirstName = "Max",
                        LastName = "Gaines"
                    };

                    IdentityResult result = await UserMgr.CreateAsync(user, "testing baby");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

        public async Task<IActionResult> Login()
        {
            var result = await SignInMgr.PasswordSignInAsync("TestUser", "testing baby", false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "Result is: " + result.ToString();
            }
            return View();
        }
    }
}
