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
    
    public partial class journals
    {
        public int id { get; set; }
        public int journalized_id { get; set; }
        public string journalized_type { get; set; }
        public int user_id { get; set; }
        public string notes { get; set; }
        public System.DateTime created_on { get; set; }
        public bool private_notes { get; set; }
    }
}
