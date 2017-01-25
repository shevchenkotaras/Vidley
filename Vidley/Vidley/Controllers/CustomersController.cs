using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidley.Models;

namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "John Smith"},
                new Customer() {Id = 2, Name = "Odarka Koschuk"}
            };

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "John Smith"},
                new Customer() {Id = 2, Name = "Odarka Koschuk"}
            };

            var customer = customers.Where(x => x.Id == id).FirstOrDefault();

            return View(customer);
        }
    }
}