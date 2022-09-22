using Blue360Media.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Blue360Media.DAL
{
    public class StateDAL
    {
        private readonly BaseDAL _baseDAL = new BaseDAL();
        public List<SelectListItem> GetAllState()
        {
            CommandType commandType = CommandType.StoredProcedure;
            int timeOut = 30;
            DataTable dt = new DataTable();
            //dt = _baseDAL.GetData("select  StateID,StateDesc from [AnnotationsDev].[LK].[States] where isActive=1");

            dt = _baseDAL.GetData("LK.GetAllState", timeOut, commandType);
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
        //string sqlText, int timeOut = 30, CommandType commandType = CommandType.Text, params IDataParameter[] sqlParams

        public List<State> GetStateTitles(string stateCode)
        {
            
            int timeOut = 30;
            CommandType commandType = CommandType.StoredProcedure;
            SqlParameter[] sp = new SqlParameter[1];
            var data = _baseDAL.GetData("select StateID from LK.states where StateCd='" + stateCode + "'");
            int getStateId =Convert.ToInt32(data.Rows[0][0]);
            sp[0] = new SqlParameter("@StateID", getStateId);
            
            var result = _baseDAL.GetData("[ant].[GetAvailTitlesForState]", timeOut, commandType, sp);
            List<State> _statelst=new List<State>();
            foreach (DataRow dr in result.Rows)
            {
                try
                {

                    State objEntity = StateMapping(dr);
                    if (objEntity != null)
                    {
                        _statelst.Add(objEntity);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return _statelst;   
        }


        private State StateMapping(DataRow dr)
        {
            return new State()
            {
                TitleID = dr[0] == DBNull.Value ? 0: Convert.ToInt64(dr[0]),
                WebsiteStatusID = dr[1] == DBNull.Value ? 0:Convert.ToInt32(dr[1]),
                WebsiteStatusDesc= dr[2] == DBNull.Value ? "" : Convert.ToString(dr[2]),
                AllowDisplayOnWebsite= dr[3] == DBNull.Value ? false : Convert.ToBoolean(dr[3]),
                AllowEditOnWebsite= dr[4] == DBNull.Value ? false : Convert.ToBoolean(dr[4]),
                DisplayLabelForWeb= dr[5] == DBNull.Value ? "" : Convert.ToString(dr[5]),
                TitleNum= dr[6] == DBNull.Value ? "" : Convert.ToString(dr[6]),
                TitleDesc= dr[7] == DBNull.Value ? "" : Convert.ToString(dr[7]),
                NumAnnotations= dr[8] == DBNull.Value ? 0 : Convert.ToInt32(dr[8]),
                //AnnotationLastUpdatedDtm= dr[9] == DBNull.Value ?Convert.ToDateTime("") : Convert.ToDateTime(dr[9]),
                AnnotationLastUpdatedDtm =dr[9]==DBNull.Value?DateTime.MinValue:Convert.ToDateTime(dr[9]),
                _AnnotationLastUpdatedDtm= dr[9] == DBNull.Value ? "" : Convert.ToDateTime(dr[9]).ToString("dd/MMM/yyyy hh:mm:ss tt"),
                AnnotationLastUserUpdate = dr[10] == DBNull.Value ? "" : Convert.ToString(dr[10]),
            };
        }
    }
}
