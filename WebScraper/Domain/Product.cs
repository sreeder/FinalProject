//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleSearch { get; set; }
        public string Description { get; set; }
        public string UPC { get; set; }
        public Nullable<int> PlatformID { get; set; }
    
        public virtual Platform Platform { get; set; }
        public virtual Price Price { get; set; }
    }
}
