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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.InvoicePositions = new HashSet<InvoicePosition>();
            this.Stocks = new HashSet<Stock>();
            this.Units = new HashSet<Unit>();
        }
    
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ExperationPeriod { get; set; }
        public byte[] Image { get; set; }
        public double Margin { get; set; }
        public int StockUnitId { get; set; }
        public int ProductStateId { get; set; }
        public int ProductTypeId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string CreatedById { get; set; }
        public System.DateTime DateModified { get; set; }
        public string ModifiedById { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoicePosition> InvoicePositions { get; set; }
        public virtual ProductState ProductState { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual Stock Stock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unit> Units { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
