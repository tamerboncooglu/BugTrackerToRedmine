//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BugTrackerLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class queued_notifications
    {
        public int qn_id { get; set; }
        public System.DateTime qn_date_created { get; set; }
        public int qn_bug { get; set; }
        public int qn_user { get; set; }
        public string qn_status { get; set; }
        public int qn_retries { get; set; }
        public string qn_last_exception { get; set; }
        public string qn_to { get; set; }
        public string qn_from { get; set; }
        public string qn_subject { get; set; }
        public string qn_body { get; set; }
    }
}
