using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using VidlyLearn.Models;
using VidlyLearn.ViewModels;

namespace VidlyLearn.Controllers
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
       
        // GET: Customers/
        [Route("Customers/")]
        public ActionResult Index()
        {
            var customers = _context.Customer.Include(customer => customer.MembershipType).ToList();


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
            var customer = _context.Customer.SingleOrDefault(customers => customers.Id == id);

            var viewModel = new CustomerVM()
            {
                Customer = customer,

            };
            if (customer == null)
                return HttpNotFound();
            return View(viewModel);
        }
      
    }
}