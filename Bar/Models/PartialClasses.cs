using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bar.Models {
    [MetadataType(typeof(InvoiceMetadata))]
    public partial class Invoice {

    }

    [MetadataType(typeof(InvoicePositionMetadata))]
    public partial class InvoicePosition {

    }

    [MetadataType(typeof(OrderMetadata))]
    public partial class Order {

    }

    [MetadataType(typeof(OrderStateMetadata))]
    public partial class OrderState {

    }

    [MetadataType(typeof(PlaceMetadata))]
    public partial class Place {

    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product {

    }

    [MetadataType(typeof(ProductStateMetadata))]
    public partial class ProductState {

    }

    [MetadataType(typeof(ProductTypeMetadata))]
    public partial class ProductType {

    }

    [MetadataType(typeof(StockMetadata))]
    public partial class Stock {

    }

    [MetadataType(typeof(UnitMetadata))]
    public partial class Unit {

    }
}