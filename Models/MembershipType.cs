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
        public static readonly byte PasyAsYouGo = 1;
        public static readonly byte Unknown = 0;
        public string Name { get; set; }

    }
}