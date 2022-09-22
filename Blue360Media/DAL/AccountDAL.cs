using Blue360Media.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blue360Media.Helper;
using Microsoft.AspNetCore.Http;

namespace Blue360Media.DAL
{
    public class AccountDAL
    {
        private readonly BaseDAL _baseDAL = new BaseDAL();

        public SessionVariables Authenticate(string userId, string password)
        {
            SqlConnection myconn = CommonVariables.GetSqlConnection();
            myconn.Open();

            SessionVariables sessionVariables = new SessionVariables();

            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("ant.AuthenticateUser", myconn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@_Email", userId));
            command.Parameters.Add(new SqlParameter("@_Password", Utility.MD5Encrypt(password)));

            dataTable.Load(command.ExecuteReader());

            if (myconn.State == ConnectionState.Open)
                myconn.Close();
            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {

                    //UserId FirstName   LastName Email   Password UserAddedOn IsActive Rolename
                    if (dr[0] != DBNull.Value)
                        sessionVariables.UserId = Convert.ToInt32(dr[0]);

                    if (dr[1] != DBNull.Value)
                        sessionVariables.FirstName = Convert.ToString(dr[1]);

                    if (dr[2] != DBNull.Value)
                        sessionVariables.LastName = Convert.ToString(dr[2]);

                    if (dr[3] != DBNull.Value)
                        sessionVariables.Email = Convert.ToString(dr[3]);

                    //if (dr[4] != DBNull.Value)
                    //    sessionVariables.Password = Convert.ToString(dr[4]);

                    if (dr[5] != DBNull.Value)
                        sessionVariables.UserAddedOn = Convert.ToString(dr[5]);

                    if (dr[6] != DBNull.Value)
                        sessionVariables.IsActive = Convert.ToBoolean(dr[6]);

                    if (dr[7] != DBNull.Value)
                    {
                        string roleName = Convert.ToString(dr[7]);
                        if (roleName == "System Administrator")
                            sessionVariables.IsSystemAdministrator = true;

                        if (roleName == "Viewer")
                            sessionVariables.IsViewer = true;

                        if (roleName == "Editor")
                            sessionVariables.IsEditor = true;
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return sessionVariables;
            //string status = "false";
            //List<string> roles = new List<string>();
            //try
            //{
            //    //CommandType commandType = CommandType.StoredProcedure;
            //    //int timeOut = 30;
            //    DataTable dt = new DataTable();
            //    DataTable dtUserRole = new DataTable();
            //    dt = _baseDAL.GetData("select * from ant.UserDetails WHERE Email='" + userId + "' And Password='"+ Utility.MD5Encrypt(password) + "' ");
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        status = "true";

            //        roles = GetRolesByUserId(Convert.ToInt32(dt.Rows[0][0]));

            //    }
            //}
            //catch
            //{
            //    status = "false";
            //}
            //return roles;
            ////return status;
        }

        public List<string> GetRolesByUserId(int userId)
        {
            SqlConnection myconn = CommonVariables.GetSqlConnection();
            myconn.Open();
            List<string> roles = new List<string>();

            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("ant.LoggedInUserRole", myconn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@UserId", userId));

            dataTable.Load(command.ExecuteReader());

            if (myconn.State == ConnectionState.Open)
                myconn.Close();
            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {
                    if(dr[0] != DBNull.Value)
                    {
                        roles.Add(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return roles;
        }
        public bool SaveUserDetail(string firstName, string lastName,string RoleId, string email, string password)
        {
            bool result = false;
            int userid = 0;
            int mapid_role = 0;
            try
            {
                CommandType cmd = CommandType.StoredProcedure;
                int timeOut = 30;
                SqlParameter[] sp = new SqlParameter[5];
                sp[0] = new SqlParameter("@FirstName", firstName);
                sp[1] = new SqlParameter("@LastName", lastName);
                sp[2] = new SqlParameter("@Email", email);
                sp[3] = new SqlParameter("@Password", Utility.MD5Encrypt(password));
                sp[4] = new SqlParameter("@RoleId",Convert.ToInt32(RoleId));

                DataTable dt = _baseDAL.GetData("ant.InsertUserDetail", timeOut, cmd, sp);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = true;
                }
            }
            catch
            {
                result=false;
            }
            return result;
        }


        public List<SelectListItem> GetUserRole()
        {
            CommandType commandType = CommandType.StoredProcedure;
            int timeOut = 30;
            DataTable dt = new DataTable();

            dt = _baseDAL.GetData("LK.GetUserRole", timeOut, commandType);
            List<SelectListItem> lst = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Select", Value = "0" }
            };
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = dt.Rows[i][1].ToString(), Value = dt.Rows[i][0].ToString() });
            }
            return lst;

        }

        public bool GetForgotPassword(string emailID)
        {
            bool result = false;
            bool mailsendingstatus = false;
            try
            {
                CommandType cmd = CommandType.StoredProcedure;
                int timeOut = 30;
                SqlParameter[] sp = new SqlParameter[1];
                sp[0] = new SqlParameter("@emailID", emailID);
                

                DataTable dt = _baseDAL.GetData("ant.GetForgotPasswordDetail", timeOut, cmd, sp);
                if (dt != null && dt.Rows.Count > 0)
                {
                    EmailSender emailSender = new EmailSender();
                    //emailSender.ClientName = Convert.ToString(dt.Rows[0]["FirstName"]+" "+ dt.Rows[0]["LastName"]);
                    //emailSender.ClientEmail = Convert.ToString(dt.Rows[0]["Email"]);
                    mailsendingstatus= EmailSender.SendEmail(emailSender);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
