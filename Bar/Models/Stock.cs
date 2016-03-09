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
    
    public partial class Stock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stock()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int StockId { get; set; }
        public int Amount { get; set; }
        public System.DateTime Expires { get; set; }
        public System.DateTime Delivered { get; set; }
        public float PurchPrice { get; set; }
        public int ProductId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string CreatedById { get; set; }
        public System.DateTime DateModified { get; set; }
        public string ModifiedById { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        public virtual Product Product { get; set; }
    }
}
