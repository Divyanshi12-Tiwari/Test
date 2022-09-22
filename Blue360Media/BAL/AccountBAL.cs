using Blue360Media.DAL;
using Blue360Media.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Blue360Media.BAL
{
    public class AccountBAL
    {
        private readonly AccountDAL _accountDAL = new AccountDAL();
        public SessionVariables Authenticate(string userId, string password)
        {
            return _accountDAL.Authenticate(userId, password);
        }

        public bool SaveUserDetail(string firstName, string lastName,string RoleId, string email, string password)
        {
            return _accountDAL.SaveUserDetail(firstName, lastName, RoleId, email, password);
        }


        public List<SelectListItem> GetUserRole()
        {
            return _accountDAL.GetUserRole();
        }

        public bool GetForgotPassword(string emailID)
        {
            return _accountDAL.GetForgotPassword(emailID);
        }
    }
}
