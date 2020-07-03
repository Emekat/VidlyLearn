using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyLearn.Models;

namespace VidlyLearn.ViewModels
{
    public class CustomerVM
    {
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}