using Blue360Media.DAL;
using Blue360Media.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Blue360Media.BAL
{
    public class StateBAL
    {
        private readonly StateDAL _stateDAL=new StateDAL();
        public List<SelectListItem> GetAllState()
        {
            return _stateDAL.GetAllState();
        }

        public List<State> GetStateTitles(string stateCode)
        {
            return _stateDAL.GetStateTitles(stateCode);
        }
    }
}
