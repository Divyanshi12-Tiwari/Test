using System;
using System.Collections.Generic;

namespace Blue360Media.Entities
{
    public class Annotation
    {

        public int TitleID { get; set; }
        public string DisplayLabelForWeb { get; set; }
        public int TitleNum { get; set; }
        public string TitleDesc { get; set; }
        public string StateCd { get; set; }
        public int DivisionID { get; set; }
        public string DivisionDesc { get; set; }
        public string DivisionHeaderHTML { get; set; }
        public string DivisionHeaderlText { get; set; }

        public string WebsiteStatusDesc { get; set; }
        public bool AllowDisplayOnWebsite { get; set; }

        public bool AllowEditOnWebsite { get; set; }
        public int NumAnnotations { get; set; }
        public DateTime AnnotationLastUpdatedDtm { get; set; }
        public string AnnotationLastUserUpdate { get; set; }

        public List<Annotation> annotation_lst { get; set; }
    }
}
