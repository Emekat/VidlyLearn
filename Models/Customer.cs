using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyLearn.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        [DisplayName("Membership Type")]
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        [DisplayName("Date Of Birth")]
        [Min18IfAMember]
        public DateTime? BirthDate { get; set; }

    }
}