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
    
    public partial class content
    {
        public int id { get; set; }
        public string title { get; set; }
        public string introtext { get; set; }
        public string fulltext { get; set; }
        public Nullable<int> state { get; set; }
        public Nullable<int> catid { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string create_by { get; set; }
        public string image { get; set; }
        public Nullable<int> ordering { get; set; }
        public Nullable<int> hit { get; set; }
        public string note { get; set; }
    
        public virtual category category { get; set; }
    }
}