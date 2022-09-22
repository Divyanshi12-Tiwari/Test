using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue360Media.BAL;
using Blue360Media.DAL;
using Blue360Media.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blue360Media.Controllers
{
    public class AccountController : Controller
    {
        //UserManager UserManager = new Microsoft.AspNetCore.Identity.UserManager();
        private readonly AccountBAL _accountBAL = new AccountBAL();
        private readonly SessionVariables _sessionVariables = new SessionVariables();
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult SignIn()
        {
            return View();
        }
        public JsonResult Authenticate(string UserId, string Password)
        {
            var sessionVariables = _accountBAL.Authenticate(UserId, Password);
            if (sessionVariables == null)
                return Json(false);
            
            HttpContext.Session.SetString("UserId", Convert.ToString(sessionVariables.UserId));
            HttpContext.Session.SetString("FirstName", Convert.ToString(sessionVariables.FirstName));
            HttpContext.Session.SetString("LastName", Convert.ToString(sessionVariables.LastName));
            HttpContext.Session.SetString("FullName", Convert.ToString(sessionVariables.FirstName+" "+ sessionVariables.LastName));
            HttpContext.Session.SetString("Email", Convert.ToString(sessionVariables.Email));
            HttpContext.Session.SetString("UserAddedOn", Convert.ToString(sessionVariables.UserAddedOn));
            HttpContext.Session.SetString("IsActive", Convert.ToString(sessionVariables.IsActive));
            HttpContext.Session.SetString("IsSystemAdministrator", Convert.ToString(sessionVariables.IsSystemAdministrator));
            HttpContext.Session.SetString("IsEditor", Convert.ToString(sessionVariables.IsEditor));
            HttpContext.Session.SetString("IsViewer", Convert.ToString(sessionVariables.IsViewer));
            return Json(true);
         
        }
        //[Authorize]
        public IActionResult Register()
        {
            return View();
        }

        public JsonResult GetUserRole()
        {
            return Json(_accountBAL.GetUserRole());
        }


        public JsonResult SaveUserDetail(string FirstName, string LastName, string RoleId, string Email, string Password)
        {
            return Json(_accountBAL.SaveUserDetail(FirstName, LastName, RoleId, Email, Password));
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public JsonResult GetForgotPassword(string emailID)
        {
            return Json(_accountBAL.GetForgotPassword(emailID));
        }

    }
}
