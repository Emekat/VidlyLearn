using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyLearn.Models;
using VidlyLearn.ViewModels;

namespace VidlyLearn.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>()
        {
            new Customer {Id = 1, Name = "Emy"},
            new Customer {Id = 2, Name = "Emeka"},
            new Customer {Id = 3, Name = "Idal"}
        };
       
        // GET: Customers/
        [Route("Customers/")]
        public ActionResult Index()
        {
            var customers = GetCustomers();


            var viewModel = new CustomerVM()
            {
                Customers = customers,
              
            };
            return View(viewModel);
        }

        // GET: Customers/Details
        // [Route("Customers/Details")]
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(customers => customers.Id == id);

            var viewModel = new CustomerVM()
            {
                Customer = customer,

            };
            if (customer == null)
                return HttpNotFound();
            return View(viewModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}