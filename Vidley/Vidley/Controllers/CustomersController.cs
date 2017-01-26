  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidley.Models;

namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            return View(customer);
        }
    }
}