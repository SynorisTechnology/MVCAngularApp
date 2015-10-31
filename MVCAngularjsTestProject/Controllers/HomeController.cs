using AutoMapper;
using MVCAngularjsTestProject.App_DataAccess;
using MVCAngularjsTestProject.App_DataModel;
using MVCAngularjsTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAngularjsTestProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("FindOrders");
        }
        public ActionResult FindOrders()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string SearchOrders(string name,string address)
        {
            OrderServices oservice = new OrderServices();
            var model= oservice.SearchOrder(name, address);
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }
        public string GetOrderItems(int orderid)
        {
            ApitestEntities dbcontext = new ApitestEntities();
            var orderitems = dbcontext.Orderitems.Where(or => or.OrderID == orderid).ToList();
            Mapper.CreateMap<Orderitem, OrderItemModel>();
            var model= Mapper.Map<List<Orderitem>, List<OrderItemModel>>(orderitems);
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }
    }
}