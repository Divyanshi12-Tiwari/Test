using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Configuration;

namespace Blue360Media.Entities
{
    public class State
    {
        public string StateDesc { get; set; }
        public string StateCode { get; set; }
        public long TitleID { get; set; }

        public long StateID { get; set; }

        public int WebsiteStatusID { get; set; }
        public string DisplayLabelForWeb { get; set; }
        public string TitleNum { get; set; }
        public string TitleDesc { get; set; }
        public string Notes { get; set; }

        public long SourceHTMLDocID { get; set; }
        public long SourceTOCID { get; set; }


        public string UserID { get; set; }
        public bool isActive { get; set; }
        public DateTime inActiveDtm { get; set; }
        public string inActiveUserID { get; set; }
        public DateTime RecDtm { get; set; }

        public string WebsiteStatusDesc{get;set;}

        public bool AllowDisplayOnWebsite { get; set; }

        public bool AllowEditOnWebsite { get; set; }
        public int NumAnnotations { get; set; }
        public Nullable<DateTime> AnnotationLastUpdatedDtm { get; set; }

        public string _AnnotationLastUpdatedDtm { get; set; }
        public string AnnotationLastUserUpdate { get; set; }
    }
}
