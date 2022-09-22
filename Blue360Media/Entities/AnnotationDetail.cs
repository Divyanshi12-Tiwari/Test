using System;

namespace Blue360Media.Entities
{
    public class AnnotationDetail
    {
        public long TitleID { get; set; }
        public long StateID { get; set; }
        public string DisplayLabelForWeb { get; set; }
        public string TitleNum { get; set; }
        public string TitleDesc { get; set; }
        public string Notes { get; set; }
        public long SourceHTMLDocID { get; set; }
        public string UserID { get; set; }
        public bool isActive { get; set; }
        public string inActiveDtm { get; set; }
        public string inActiveUserID { get; set; }
        public string RecDtm { get; set; }
        public long DivisionID { get; set; }
        public int WebsiteStatusID { get; set; }
        public int DivisionTypeID { get; set; }
        public string DivisionNum { get; set; }
        public string DivisionDesc { get; set; }
        public string DivisionHeaderHTML { get; set; }
        public string DivisionHeaderlText { get; set; }
        public long SourceSectionRowID { get; set; }

        public long AnnotationID { get; set; }
        public string CaseName { get; set; }
        public string CaseLink { get; set; }
        public string Citation { get; set; }
        public string CaseBlurb { get; set; }
    }
}
