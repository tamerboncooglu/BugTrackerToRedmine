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
    
    public partial class wiki_content_versions
    {
        public int id { get; set; }
        public int wiki_content_id { get; set; }
        public int page_id { get; set; }
        public Nullable<int> author_id { get; set; }
        public byte[] data { get; set; }
        public string compression { get; set; }
        public string comments { get; set; }
        public System.DateTime updated_on { get; set; }
        public int version { get; set; }
    }
}