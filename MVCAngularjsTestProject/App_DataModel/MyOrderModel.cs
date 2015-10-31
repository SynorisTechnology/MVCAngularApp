using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngularjsTestProject.App_DataModel
{
    public class MyOrderModel
    {

        public int OrderID { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string Status { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string PaymentInfo { get; set; }
        public string PaymentMethod { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public string DeliveryMethod { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }

    }
}