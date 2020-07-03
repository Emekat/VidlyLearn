using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace VidlyLearn.Models
{
    public class MembershipType
    {
        public short SignUpFee { get; set; }
        public byte Id { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }



    }
}