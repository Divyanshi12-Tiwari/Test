using System.Data;
using System.Diagnostics;
using System;
using System.Data.SqlClient;
using Blue360Media.Helper;

namespace Blue360Media.DAL
{
    public class BaseDAL
    {
        public static string sqlDataSource = CommonVariables.ConnectionString;
        //private readonly ErrorLogDAL _errorLogDAL = new ErrorLogDAL();

        /// <summary>
        /// Execute sql query and return datatable
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="timeOut"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public DataTable GetData(string sqlText, int timeOut = 30, CommandType commandType = CommandType.Text, params IDataParameter[] sqlParams)
        {
            DataTable result = new DataTable();
            try
            {

                SqlDataReader reader;
                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn) { CommandType = commandType })
                    {
                        if (sqlParams.Length > 0)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                        }
                        //cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = timeOut;
                        reader = cmd.ExecuteReader();
                        result.Load(reader);
                        reader.Close();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //_errorLogDAL.SaveErrorLog(new ErrorLog()
                //{
                //    CreatedOnDttm = DateTime.Now,
                //    ErrorMessage = ex.Message,
                //    Url = "Database Call Error::" + new StackTrace().GetFrame(1).GetMethod().Name + "==>" + sqlText,
                //});
            }
            return result;
        }

        /// <summary>
        /// Execute sql query and return jsonObject string
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="jsonOutputParam"></param>
        /// <param name="timeOut"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public string GetJsonData(string sqlText, string jsonOutputParam, int timeOut = 30, CommandType commandType = CommandType.Text, params IDataParameter[] sqlParams)
        {
            try
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                var bfhj = st.GetFrame(1).GetMethod().Name;

                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn) { CommandType = commandType })
                    {
                        if (sqlParams.Length > 0)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                        }
                        cmd.Parameters.Add(jsonOutputParam, SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                        cmd.CommandTimeout = timeOut;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        jsonOutputParam = cmd.Parameters[jsonOutputParam].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //_errorLogDAL.SaveErrorLog(new ErrorLog()
                //{

                //    CreatedOnDttm = DateTime.Now,
                //    ErrorMessage = ex.Message,
                //    Url = "Database Call Error::" + new StackTrace().GetFrame(1).GetMethod().Name + "==>" + sqlText,
                //});
                jsonOutputParam = "";
            }
            return jsonOutputParam; ;
        }
        public int GetIntData(string sqlText, string intOutputParam, int timeOut = 30, CommandType commandType = CommandType.Text, params IDataParameter[] sqlParams)
        {
            int returnData = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn) { CommandType = commandType })
                    {
                        if (sqlParams.Length > 0)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                        }
                        cmd.Parameters.Add(intOutputParam, SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                        cmd.CommandTimeout = timeOut;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        returnData = Convert.ToInt32(cmd.Parameters[intOutputParam].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                //_errorLogDAL.SaveErrorLog(new ErrorLog()
                //{
                //    CreatedOnDttm = DateTime.Now,
                //    ErrorMessage = ex.Message,
                //    Url = "Database Call Error::" + new StackTrace().GetFrame(1).GetMethod().Name + "==>" + sqlText,
                //});
            }
            return returnData;
        }

        /// <summary>
        /// Execute sql query and return result identity
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="timeOut"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public int SetData(string sqlText, int timeOut = 30, CommandType commandType = CommandType.Text, params IDataParameter[] sqlParams)
        {
            int rows = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn) { CommandType = commandType })
                    {
                        if (sqlParams.Length > 0)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                        }
                        cmd.CommandTimeout = timeOut;
                        rows= cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //_errorLogDAL.SaveErrorLog(new ErrorLog()
                //{
                //    CreatedOnDttm = DateTime.Now,
                //    ErrorMessage = ex.Message,
                //    Url = "Database Call Error::" + new StackTrace().GetFrame(1).GetMethod().Name + "==>" + sqlText,
                //});
            }
            return rows;
        }
        /// <summary>
        /// Execute sql query and return result identity
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="timeOut"></param>
        /// <param name="commandType"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public int InsertData(string sqlText, int timeOut = 30, CommandType commandType = CommandType.Text, params IDataParameter[] sqlParams)
        {
            int rows = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn) { CommandType = commandType })
                    {
                        if (sqlParams.Length > 0)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                        }
                        cmd.CommandTimeout = timeOut;
                        rows = (int)cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //_errorLogDAL.SaveErrorLog(new ErrorLog()
                //{
                //    CreatedOnDttm = DateTime.Now,
                //    ErrorMessage = ex.Message,
                //    Url = "Database Call Error::" + new StackTrace().GetFrame(1).GetMethod().Name + "==>" + sqlText,
                //});
            }
            return rows;
        }
        public int CheckData(string sqlText, int timeOut = 30, CommandType commandType = CommandType.Text, params IDataParameter[] sqlParams)
        {
            int rows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlDataSource))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlText, conn) { CommandType = commandType })
                    {
                        if (sqlParams.Length > 0)
                        {
                            foreach (IDataParameter para in sqlParams)
                            {
                                cmd.Parameters.Add(para);
                            }
                        }
                        cmd.CommandTimeout = timeOut;
                        rows = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                //_errorLogDAL.SaveErrorLog(new ErrorLog()
                //{
                //    CreatedOnDttm = DateTime.Now,
                //    ErrorMessage = ex.Message,
                //    Url = "Database Call Error::" + new StackTrace().GetFrame(1).GetMethod().Name + "==>" + sqlText,
                //});
            }
            return rows;
        }
    }
}
