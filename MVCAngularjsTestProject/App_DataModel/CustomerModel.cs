using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngularjsTestProject.App_DataModel
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}