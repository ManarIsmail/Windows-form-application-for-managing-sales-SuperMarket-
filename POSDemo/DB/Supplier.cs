//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POSDemo.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}