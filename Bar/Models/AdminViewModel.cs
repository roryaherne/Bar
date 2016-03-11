using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bar.Models {
    public class AdminViewModel {
        public List<OrderState> OrderStates { get; set; }
        public List<Place> Places { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductState> ProductStates { get; set; }
        public List<ProductType> ProductTypes { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<Unit> Units { get; set; }
    }
}