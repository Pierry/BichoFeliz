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
    
    public partial class CONTATO
    {
        public CONTATO()
        {
            this.ANIMALs = new HashSet<ANIMAL>();
            this.USUARIOs = new HashSet<USUARIO>();
            this.SERVICOes = new HashSet<SERVICO>();
        }
    
        public int IDCONTATO { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string ESTADO { get; set; }
        public Nullable<int> STATUS { get; set; }
        public Nullable<int> PERFIL { get; set; }
    
        public virtual ICollection<ANIMAL> ANIMALs { get; set; }
        public virtual ICollection<USUARIO> USUARIOs { get; set; }
        public virtual ICollection<SERVICO> SERVICOes { get; set; }
    }
}
