using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movieRental.Models;

namespace movieRental.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = GetCustomers();
            var filteredCustomer = customers.FirstOrDefault(c => c.Id == id);

            if (filteredCustomer == null)
                return HttpNotFound();

            return View(filteredCustomer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "Lonwabo Mnyaiza" });
            customers.Add(new Customer { Id = 2, Name = "Mivuyo Mnyaiza" });

            return customers;
        }
    }
}