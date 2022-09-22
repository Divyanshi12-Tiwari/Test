using Blue360Media.DAL;
using Blue360Media.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Blue360Media.BAL
{

    public class AnnotationBAL
    {
        private readonly AnnotationDAL _annotationDAL = new AnnotationDAL();

        public List<Annotation> GetAnnotations()
        {
            return _annotationDAL.GetAnnotations(); 
        }

        public List<Annotation> GetAnnotationDetailByStateTitle(string stateCd, int titleID)
        {
            return _annotationDAL.GetAnnotationDetailByStateTitle(stateCd, titleID);
        }

        public List<AnnotationDetail> GetAnnotationDetailByDivisionId(int divisionID)
        {
            return _annotationDAL.GetAnnotationDetailByDivisionId(divisionID);
        }
        public void UpdateDivisionStatus(int _DivisionId, int _EditStatusId, int _UserId)
        {
            _annotationDAL.UpdateDivisionStatus(_DivisionId, _EditStatusId, _UserId);   
        }
        public List<EditStatus> GetEditStatus(int divisionID)
        {
            return _annotationDAL.GetEditStatus(divisionID);
        }

        [HttpPost]
        public bool UpdateAnnotationDetail(int annotationID, string caseName, string caseLink, string citation, string blurb,int userID,string userEmail,int divisionID)
        {
            return _annotationDAL.UpdateAnnotationDetail(annotationID, caseName, caseLink, citation, blurb, userID, userEmail, divisionID);
        }
        public bool DeleteAnnotation(int annotationID)
        {
            return _annotationDAL.DeleteAnnotation(annotationID);
        }
    }
}
