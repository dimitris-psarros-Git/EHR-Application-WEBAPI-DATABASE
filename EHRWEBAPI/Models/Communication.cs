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
    
    public partial class Communication
    {
        public int CommunicationID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string email { get; set; }
        public Nullable<int> Telephone { get; set; }
    
        public virtual Patient Patient {internal get; set; }
    }
}
