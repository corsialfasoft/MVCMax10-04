//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC10_04
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdiniProdotti
    {
        public int Ordini_Id { get; set; }
        public int Prodotti_Id { get; set; }
        public int quantita { get; set; }
    
        public virtual OrdiniSet OrdiniSet { get; set; }
        public virtual ProdottiSet ProdottiSet { get; set; }
    }
}
