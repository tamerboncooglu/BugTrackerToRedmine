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
    
    public partial class wiki_pages
    {
        public int id { get; set; }
        public int wiki_id { get; set; }
        public string title { get; set; }
        public System.DateTime created_on { get; set; }
        public bool @protected { get; set; }
        public Nullable<int> parent_id { get; set; }
    }
}
