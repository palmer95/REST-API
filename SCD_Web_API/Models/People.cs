using System;
using System.Collections.Generic;

namespace SCD_Web_API.Models
{
    public partial class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
