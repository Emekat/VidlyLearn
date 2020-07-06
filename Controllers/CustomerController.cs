using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using VidlyLearn.Models;
using VidlyLearn.ViewModels;

namespace VidlyLearn.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
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
            var customers = _context.Customers.Include(customer => customer.MembershipType).ToList();


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
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(customers => customers.Id == id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerVM(customer);
           
            return View(viewModel);
        }

        public ActionResult CustomerForm()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerVM()
            {
                MembershipTypes = membershipType
            };
            return View(viewModel);
        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerVM()
            {
                MembershipTypes = membershipType,
               
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerVM(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipType = customer.MembershipType;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
        
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
          
            var viewModel = new CustomerVM(customer)
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}