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
    
    public partial class roles
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> position { get; set; }
        public Nullable<bool> assignable { get; set; }
        public int builtin { get; set; }
        public string permissions { get; set; }
        public string issues_visibility { get; set; }
    }
}