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
    
    public partial class ANIMAL
    {
        public ANIMAL()
        {
            this.SERVICOes = new HashSet<SERVICO>();
        }
    
        public int IDANIMAL { get; set; }
        public Nullable<int> IDCONTATO { get; set; }
        public Nullable<int> IDRACA { get; set; }
        public string NOME { get; set; }
        public Nullable<int> STATUS { get; set; }
    
        public virtual CONTATO CONTATO { get; set; }
        public virtual RACA RACA { get; set; }
        public virtual ICollection<SERVICO> SERVICOes { get; set; }
    }
}