//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace education.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class menu
    {
        public int id { get; set; }
        public string title { get; set; }
        public string note { get; set; }
        public string link { get; set; }
        public Nullable<int> parent_id { get; set; }
        public Nullable<int> level { get; set; }
        public Nullable<int> ordering { get; set; }
        public Nullable<int> home { get; set; }
        public string image { get; set; }
        public Nullable<int> published { get; set; }
    }
}
