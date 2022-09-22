using Blue360Media.BAL;
using Blue360Media.DAL;
using Blue360Media.Entities;
using Blue360Media.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blue360Media.Controllers
{
    public class AnnotationController : Controller
    {
        AnnotationBAL _annotationBAL = new AnnotationBAL();
        public IActionResult Index(string id,string StateCode)
        {
            Annotation annotation = new Annotation();
            annotation.StateCd = StateCode;
            annotation.TitleID = Convert.ToInt32(id);
            return View(annotation);
        }

        public JsonResult GetAnnotationDetailByStateTitle(string StateCd,int TitleID)
        {
            return Json(_annotationBAL.GetAnnotationDetailByStateTitle(StateCd, TitleID));
        }
        public IActionResult AnnotationDetail(int divisionid)
        {
            AnnotationDetail _annotationDetail = new AnnotationDetail();
            _annotationDetail.DivisionID = divisionid;
            return View(_annotationDetail);
        }

        public JsonResult GetAnnotationDetailByDivisionId(int divisionID)
        {

            return Json(new { annotationList=_annotationBAL.GetAnnotationDetailByDivisionId(divisionID),annotationStatus= _annotationBAL.GetEditStatus(divisionID) });
        }

        //public JsonResult GetEditStatus()
        //{
        //    return Json(_annotationBAL.GetEditStatus());
        //}
        [HttpPost]
        public JsonResult UpdateAnnotationDetail(int annotationID, string caseName, string caseLink, string citation, string blurb, int divisionID)
        {
            blurb=Utility.HTMLToText(blurb);
            return Json(_annotationBAL.UpdateAnnotationDetail(annotationID, caseName, caseLink, citation, blurb, Convert.ToInt32(HttpContext.Session.GetString("UserId")),Convert.ToString(HttpContext.Session.GetString("Email")), divisionID));
        }
        public JsonResult UpdateDivisionStatus(int editStatusId, int divisionID)
        {
            _annotationBAL.UpdateDivisionStatus(divisionID, editStatusId, Convert.ToInt32(HttpContext.Session.GetString("UserId")));
            return Json(true);
        }

        public JsonResult DeleteAnnotation(int annotationID)
        {
            return Json(_annotationBAL.DeleteAnnotation(annotationID));
        }
    }
}
