using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Domain
{
    public class Address : IAddress
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }
    }
}
