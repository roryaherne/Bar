using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bar.Models {
    public class BaseMetadata {
        [Display(Name = "Submitted By")]
        public string CreatedById;

        [Display(Name = "Modified By")]
        public string ModifiedById;

        [Display(Name = "Date Submitted")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DateCreated;

        [Display(Name = "Date Modified")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime DateModified;
    }

    public class InvoiceMetadata : BaseMetadata {

    }

    public class InvoicePositionMetadata : BaseMetadata {

    }

    public class OrderMetadata : BaseMetadata {

    }

    public class OrderStateMetadata : BaseMetadata {

    }

    public class PlaceMetadata : BaseMetadata {

    }

    public class ProductMetadata : BaseMetadata {

    }

    public class ProductStateMetadata : BaseMetadata {

    }

    public class ProductTypeMetadata : BaseMetadata {

    }

    public class StockMetadata : BaseMetadata {

    }

    public class UnitMetadata : BaseMetadata {

    }
}