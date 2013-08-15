using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.PersonDetails.Domain.Contracts
{
    public interface IAddress
    {
        string AddressLine1 { get; set; }

        string AddressLine2 { get; set; }

        string City { get; set; }

        string State { get; set; }

        string Country { get; set; }

        int ZipCode { get; set; }
    }
}
