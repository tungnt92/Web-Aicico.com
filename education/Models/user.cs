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
    
    public partial class user
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string image { get; set; }
        public Nullable<int> level { get; set; }
    }
}
