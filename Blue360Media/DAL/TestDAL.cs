using Blue360Media.Helper;
using Microsoft.AspNetCore.WebUtilities;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System;
using Blue360Media.Entities;
using System.Collections.Generic;

namespace Blue360Media.DAL
{
    public class TestDAL
    {
        public State Get_LookInfo(int serviceID)
        {
            SqlConnection myconn = CommonVariables.GetSqlConnection();

            State lookInfo = new State();

            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("[dbo].[GetLookInfo]", myconn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("pictureId", serviceID));

            dataTable.Load(command.ExecuteReader());

            if (myconn.State == ConnectionState.Open)
                myconn.Close();
            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {
                    var objEntity = StateMapping(dr);
                    if (objEntity != null)
                    {
                        lookInfo = objEntity;
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return lookInfo;
        }
        public List<State> Get_LookList(int serviceID)
        {
            SqlConnection myconn = CommonVariables.GetSqlConnection();

            List<State> lookInfo = new List<State>();

            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("[dbo].[GetLookInfo]", myconn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("pictureId", serviceID));

            dataTable.Load(command.ExecuteReader());

            if (myconn.State == ConnectionState.Open)
                myconn.Close();
            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {
                    var objEntity = StateMapping(dr);
                    if (objEntity != null)
                    {
                        lookInfo.Add(objEntity);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return lookInfo;
        }

        private State StateMapping(DataRow dr)
        {
            return new State()
            {
                StateID = dr[0] == DBNull.Value ? Convert.ToInt32(dr[0]) : 0,
                StateCode= dr[1] == DBNull.Value ? Convert.ToString(dr[0]) : "",
            };
        }
    }
}
