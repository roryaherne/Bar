//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderId { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public System.DateTime OrderTime { get; set; }
        public int InvoiceId { get; set; }
        public int InvoicePosId { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public int PlaceId { get; set; }
        public int OrderStateId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string CreatedById { get; set; }
        public System.DateTime DateModified { get; set; }
        public string ModifiedById { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
        public virtual InvoicePosition InvoicePosition { get; set; }
        public virtual OrderState OrderState { get; set; }
        public virtual Place Place { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
