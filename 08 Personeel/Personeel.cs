//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _08_Personeel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personeel
    {
        public Personeel()
        {
            this.Ondergeschikten = new HashSet<Personeel>();
        }
    
        public int PersoneelsNr { get; set; }
        public string Voornaam { get; set; }
        public Nullable<int> ManagerNr { get; set; }
    
        public virtual ICollection<Personeel> Ondergeschikten { get; set; }
        public virtual Personeel Manager { get; set; }
    }
}
