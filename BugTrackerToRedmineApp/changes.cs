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
    
    public partial class changes
    {
        public int id { get; set; }
        public int changeset_id { get; set; }
        public string action { get; set; }
        public string path { get; set; }
        public string from_path { get; set; }
        public string from_revision { get; set; }
        public string revision { get; set; }
        public string branch { get; set; }
    }
}