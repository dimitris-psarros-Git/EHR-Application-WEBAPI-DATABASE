//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EHRWEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int UserID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDoctor { get; set; }
        public string Key { get; set; }
        public string Salt { get; set; }
    
        public virtual Demographic Demographic { get; set; }
    }
}
