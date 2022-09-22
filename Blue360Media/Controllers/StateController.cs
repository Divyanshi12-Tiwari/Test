using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blue360Media.BAL;
using Blue360Media.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blue360Media.Controllers
{
    public class StateController : Controller
    {
        private readonly StateBAL _stateBAL = new StateBAL();
        /// <summary>
        /// Get the list of state by code
        /// </summary>
        /// <param name="state_code"></param>
        /// <returns></returns>
        public IActionResult List()
        {
            //ViewBag.LoggedInUserFullName = HttpContext.Session.GetString("LoggedInUserFullName");
            return View();
        }

        public JsonResult GetAllState()
        {
            return Json(_stateBAL.GetAllState());
        }

        public JsonResult GetStateTitles(string stateCode)
        {
            return Json(_stateBAL.GetStateTitles(stateCode));
        }

        public IActionResult Detail(string state_code,string statename)
        {
            State model = new State()
            {
                StateCode = state_code,
                StateDesc= statename,    
            };
            return View(model);
        }

    }
}
