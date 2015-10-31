using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngularjsTestProject.App_DataModel
{
    public class OrderItemModel
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> CouponCode { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }

    }
}