using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using VidlyLearn.Models;

namespace VidlyLearn.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerVM
    {
        public CustomerVM()
        {
            Id = 0;
        }

        public CustomerVM(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            BirthDate = customer.BirthDate;
            MembershipTypeId = customer.MembershipTypeId;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
        }

        [Required]
        public int? Id { get; set; }
      
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [DisplayName("Membership Type")]
        public MembershipType MembershipType { get; set; }

        [DisplayName("Membership Type")]
        public byte MembershipTypeId { get; set; }

        [DisplayName("Date Of Birth")]
        [Min18IfAMember]
        public DateTime? BirthDate { get; set; }

        public List<Customer> Customers { get; set; }
      
        //public Customer Customer { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }
    }
}