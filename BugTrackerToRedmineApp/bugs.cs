//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BugTrackerToRedmineApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class bugs
    {
        public int bg_id { get; set; }
        public string bg_short_desc { get; set; }
        public int bg_reported_user { get; set; }
        public System.DateTime bg_reported_date { get; set; }
        public int bg_status { get; set; }
        public int bg_priority { get; set; }
        public int bg_org { get; set; }
        public int bg_category { get; set; }
        public int bg_project { get; set; }
        public Nullable<int> bg_assigned_to_user { get; set; }
        public Nullable<int> bg_last_updated_user { get; set; }
        public Nullable<System.DateTime> bg_last_updated_date { get; set; }
        public Nullable<int> bg_user_defined_attribute { get; set; }
        public string bg_project_custom_dropdown_value1 { get; set; }
        public string bg_project_custom_dropdown_value2 { get; set; }
        public string bg_project_custom_dropdown_value3 { get; set; }
        public string bg_tags { get; set; }
        public string Bildiren { get; set; }
        public string Nasıl_oluşturuluyor { get; set; }
    }
}
