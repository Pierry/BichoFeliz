//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BichoFelizMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class RACA
    {
        public RACA()
        {
            this.ANIMALs = new HashSet<ANIMAL>();
        }
    
        public int IDRACA { get; set; }
        public Nullable<int> IDTIPO { get; set; }
        public string NOME { get; set; }
        public Nullable<int> STATUS { get; set; }
    
        public virtual ICollection<ANIMAL> ANIMALs { get; set; }
        public virtual TIPO TIPO { get; set; }
    }
}
