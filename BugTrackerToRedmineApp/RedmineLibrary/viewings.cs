//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedmineLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class viewings
    {
        public int id { get; set; }
        public Nullable<int> viewer_id { get; set; }
        public Nullable<int> viewed_id { get; set; }
        public string viewed_type { get; set; }
        public string ip { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
    }
}