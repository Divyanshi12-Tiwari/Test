using Blue360Media.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Blue360Media.Helper;

namespace Blue360Media.DAL
{
    public class AnnotationDAL
    {
        private readonly BaseDAL _baseDAL = new BaseDAL();

        public List<Annotation> GetAnnotations()
        {
            var result = _baseDAL.GetData("select * from [b360].[Annotations]");
            return Helper.Helper.DataTableToObjectList<Annotation>(result);
        }

        public List<Annotation> GetAnnotationDetailByStateTitle(string stateCd, int titleID)
        {
            int timeOut = 30;
            CommandType commandType = CommandType.StoredProcedure;
            SqlParameter[] sp = new SqlParameter[1];
            //sp[0] = new SqlParameter("@StateCode", stateCd);
            sp[0] = new SqlParameter("@TitleId", titleID);
            Annotation obj = new Annotation();

            var result = _baseDAL.GetData("ant.GetAnnotationDetailByStateAndTitle", timeOut, commandType, sp);
            List<Annotation> _annotationlst = new List<Annotation>();
            foreach (DataRow dr in result.Rows)
            {
                try
                {

                    Annotation objEntity = AnnotationMapping(dr);
                    if (objEntity != null)
                    {
                        _annotationlst.Add(objEntity);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            obj.annotation_lst = _annotationlst;
            return obj.annotation_lst;
        }

        private Annotation AnnotationMapping(DataRow dr)
        {
            return new Annotation()
            {
                TitleID = dr[0] == DBNull.Value ? 0 : Convert.ToInt32(dr[0]),
                DisplayLabelForWeb = dr[1] == DBNull.Value ? "" : Convert.ToString(dr[1]),
                TitleNum = dr[2] == DBNull.Value ? 0 : Convert.ToInt32(dr[2]),
                TitleDesc = dr[3] == DBNull.Value ? "" : Convert.ToString(dr[3]),
                StateCd = dr[4] == DBNull.Value ? "" : Convert.ToString(dr[4]),
                DivisionID = dr[5] == DBNull.Value ? 0 : Convert.ToInt32(dr[5]),
                DivisionDesc = dr[6] == DBNull.Value ? "" : Convert.ToString(dr[6]),
                DivisionHeaderHTML = dr[8] == DBNull.Value ? "" : Convert.ToString(dr[8]),
                DivisionHeaderlText = dr[9] == DBNull.Value ? "" : Convert.ToString(dr[9]),
                WebsiteStatusDesc = dr[10] == DBNull.Value ? "" : Convert.ToString(dr[10]),
                AllowDisplayOnWebsite = dr[11] == DBNull.Value ? false : Convert.ToBoolean(dr[11]),
                AllowEditOnWebsite = dr[12] == DBNull.Value ? false : Convert.ToBoolean(dr[12]),
                NumAnnotations = dr[13] == DBNull.Value ? 0 : Convert.ToInt32(dr[13]),
                AnnotationLastUpdatedDtm = dr[14] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[14]),
                AnnotationLastUserUpdate = dr[15] == DBNull.Value ? "" : Convert.ToString(dr[15]),


            };
        }

        public List<AnnotationDetail> GetAnnotationDetailByDivisionId(int divisionID)
        {
            int timeOut = 30;
            CommandType commandType = CommandType.StoredProcedure;
            SqlParameter[] sp = new SqlParameter[1];
            sp[0] = new SqlParameter("@divisionID", divisionID);
            AnnotationDetail obj = new AnnotationDetail();

            var result = _baseDAL.GetData("ant.GetAnnotationDetailByDivisionID", timeOut, commandType, sp);
            List<AnnotationDetail> _annotationlstBydivisionID = new List<AnnotationDetail>();
            foreach (DataRow dr in result.Rows)
            {
                try
                {

                    AnnotationDetail objEntity = AnnotationMappingBydivisionID(dr);
                    if (objEntity != null)
                    {
                        _annotationlstBydivisionID.Add(objEntity);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return _annotationlstBydivisionID;
        }


        private AnnotationDetail AnnotationMappingBydivisionID(DataRow dr)
        {
            return new AnnotationDetail()
            {

                TitleID = dr[0] == DBNull.Value ? 0 : Convert.ToInt64(dr[0]),
                StateID = dr[1] == DBNull.Value ? 0 : Convert.ToInt64(dr[1]),
                DisplayLabelForWeb = dr[2] == DBNull.Value ? "" : Convert.ToString(dr[2]),
                TitleNum = dr[3] == DBNull.Value ? "" : Convert.ToString(dr[3]),
                TitleDesc = dr[4] == DBNull.Value ? "" : Convert.ToString(dr[4]),
                Notes = dr[5] == DBNull.Value ? "" : Convert.ToString(dr[5]),
                SourceHTMLDocID = dr[6] == DBNull.Value ? 0 : Convert.ToInt64(dr[6]),
                UserID = dr[7] == DBNull.Value ? "" : Convert.ToString(dr[7]),
                isActive = dr[8] == DBNull.Value ? false : Convert.ToBoolean(dr[8]),
                inActiveDtm = dr[9] == DBNull.Value ? "" : Convert.ToString(dr[9]),
                inActiveUserID = dr[10] == DBNull.Value ? "" : Convert.ToString(dr[10]),
                RecDtm = dr[11] == DBNull.Value ? "" : Convert.ToString(dr[11]),
                DivisionID = dr[12] == DBNull.Value ? 0 : Convert.ToInt64(dr[12]),
                WebsiteStatusID = dr[13] == DBNull.Value ? 0 : Convert.ToInt32(dr[13]),
                DivisionTypeID = dr[14] == DBNull.Value ? 0 : Convert.ToInt32(dr[14]),
                DivisionNum = dr[15] == DBNull.Value ? "" : Convert.ToString(dr[15]),
                DivisionDesc = dr[33] == DBNull.Value ? "" : Convert.ToString(dr[33]),
                DivisionHeaderHTML = dr[17] == DBNull.Value ? "" : Convert.ToString(dr[17]),
                DivisionHeaderlText = dr[18] == DBNull.Value ? "" : Convert.ToString(dr[18]),
                SourceSectionRowID = dr[19] == DBNull.Value ? 0 : Convert.ToInt64(dr[19]),
                AnnotationID= dr[20] == DBNull.Value ? 0 : Convert.ToInt64(dr[20]),
                CaseName= dr[22] == DBNull.Value ? "" : Convert.ToString(dr[22]),
                CaseLink = dr[23] == DBNull.Value ? "" : Convert.ToString(dr[23]),
                Citation = dr[24] == DBNull.Value ? "" : Convert.ToString(dr[24]),
                CaseBlurb = dr[25] == DBNull.Value ? "" : Convert.ToString(dr[25]),
            };
        }

       
        public void UpdateDivisionStatus(int _DivisionId, int _EditStatusId, int _UserId)
        {
            SqlConnection myconn = CommonVariables.GetSqlConnection();
            myconn.Open();
            List<string> roles = new List<string>();

            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("ant.UpdateDivisionStatus", myconn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@_DivisionId", _DivisionId));
            command.Parameters.Add(new SqlParameter("@_EditStatusId", _EditStatusId));
            command.Parameters.Add(new SqlParameter("@_UserId", _UserId));

            command.ExecuteNonQuery();

            if (myconn.State == ConnectionState.Open)
                myconn.Close();
        }
        public List<EditStatus> GetEditStatus(int divisionID)
        {
            
          
            DataTable dt = new DataTable();
            dt = _baseDAL.GetData("select es.Id, es.Status, ISNULL(ds.IsActive,0) as 'IsChecked' from LK.EditStatus es Left join [ant].[DivisionStatus] ds on es.Id=ds.EditStatusId and ds.DivisionId="+divisionID+" and ds.IsActive=1 ");
            //dt = _baseDAL.GetData("select Id,[Status] from LK.EditStatus WHERE IsActive=1 ");
            List<EditStatus> lst = new List<EditStatus>
            {
                //new SelectListItem() { Text = "Select", Value = "0" }
            };

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                lst.Add(new EditStatus()
                {
                    Id=Convert.ToInt32(dt.Rows[i][0]),
                    Status = Convert.ToString(dt.Rows[i][1]),
                    //IsActive= Convert.ToBoolean(dt.Rows[i][1]),
                    IsChecked= Convert.ToBoolean(dt.Rows[i][2])
                });
                //lst.Add(new SelectListItem() { Text = dt.Rows[i][1].ToString(), Value = dt.Rows[i][0].ToString() });
            }
            return lst;
        }

        public bool UpdateAnnotationDetail(int annotationID, string caseName, string caseLink, string citation, string blurb,int userID,string userEmail,int divisionID)
        {
            bool status = false;
            try
            {
                int timeOut = 30;
                CommandType commandType = CommandType.StoredProcedure;
                SqlParameter[] sp = new SqlParameter[8];
                sp[0] = new SqlParameter("@annotationID", annotationID);
                sp[1] = new SqlParameter("@caseName", caseName);
                sp[2] = new SqlParameter("@caseLink", caseLink);
                sp[3] = new SqlParameter("@citation", citation);
                sp[4] = new SqlParameter("@blurb", blurb);
                sp[5] = new SqlParameter("@userID",Convert.ToInt32(userID));
                sp[6] = new SqlParameter("@userEmail", userEmail);
                sp[7] = new SqlParameter("@divisionID", divisionID);

                int result = _baseDAL.SetData("ant.UpdateAnnotationDetail", timeOut, commandType, sp);
                if(result>0)
                {
                    status = true;
                }

            }
            catch
            {
                status = false;
            }
            return status;
        }

        public bool DeleteAnnotation(int annotationID)
        {
            bool status = false;
            try
            {
                int timeOut = 30;
                CommandType commandType = CommandType.StoredProcedure;
                SqlParameter[] sp = new SqlParameter[1];
                sp[0] = new SqlParameter("@annotationID", annotationID);
                int result = _baseDAL.SetData("ant.DeleteAnnotation", timeOut, commandType, sp);
                if (result > 0)
                {
                    status = true;
                }

            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
