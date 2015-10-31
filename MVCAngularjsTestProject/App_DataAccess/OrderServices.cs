using MVCAngularjsTestProject.App_DataModel;
using MVCAngularjsTestProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCAngularjsTestProject.App_DataAccess
{
    public interface IOrderServices
    {
        int AddOrder(MyOrderModel model);
        int EditOrder(MyOrderModel model);
        List<CustomerOrderModel> SearchOrder(string customerName, string address);
    }
    public class OrderServices : DataFunctions,IOrderServices
    {
        public int AddOrder(MyOrderModel model)
        {
            throw new NotImplementedException();
        }

        public int EditOrder(MyOrderModel model)
        {
            throw new NotImplementedException();
        }

        // FullText Search.
        public List<CustomerOrderModel> SearchOrder(string customerName, string address)
        {
            Hashtable ht = new Hashtable();
            ht.Add("CustomerName", customerName);
            ht.Add("Address", address);
            DataTable dt = GetDataTableFromProcedure("SpSearchCustomer", ht);
            List<CustomerOrderModel> model = new List<CustomerOrderModel>();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                     CustomerOrderModel cust = new CustomerOrderModel();
                    cust.Address = row["Address"].ToString();
                    cust.ContactNo = row["ContactNo"].ToString();
                    cust.Country = row["Country"].ToString();
                    cust.Email = row["Email"].ToString();
                    cust.FullName = row["FullName"].ToString();
                    cust.Mobile = row["Mobile"].ToString();
                    cust.ZipCode = row["ZipCode"].ToString();
                    cust.ContactNo = row["ContactNo"].ToString();
                    cust.EmailID = row["EmailID"].ToString();
                    string orderdate = row["OrderDate"].ToString();
                    if (row["OrderDate"].ToString() != null && orderdate!="")
                        cust.OrderDate = Convert.ToDateTime(row["OrderDate"].ToString());
                    cust.InvoiceNo = row["InvoiceNo"].ToString();
                    cust.OrderID = Convert.ToInt32(row["OrderID"].ToString());
                    cust.PaymentInfo = row["PaymentInfo"].ToString();
                    cust.PaymentMethod = row["PaymentMethod"].ToString();
                    cust.State = row["State"].ToString();
                    cust.State2 = row["State2"].ToString();
                    cust.Status = row["Status"].ToString();
                    if (row["TaxAmount"].ToString() != null && row["TaxAmount"].ToString()!="")
                        cust.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString());
                    cust.ZipCode = row["ZipCode"].ToString();
                    cust.ZipCode2 = row["ZipCode2"].ToString();
                    cust.CustomerID = Convert.ToInt32(row["CustomerID"].ToString());
                    cust.DeliveryAddress = row["DeliveryAddress"].ToString();
                    cust.DeliveryAddress2 = row["DeliveryAddress2"].ToString();
                    cust.DeliveryMethod = row["DeliveryMethod"].ToString();
                    cust.Email = row["Email"].ToString();
                    if (row["TotalAmount"].ToString() != null && row["TotalAmount"].ToString() != "")
                        cust.TotalAmount = Convert.ToDecimal(row["TotalAmount"].ToString());

                    model.Add(cust);
                }
            }
            return model;
        }
    }
}