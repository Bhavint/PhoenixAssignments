using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.PersonDetails.Domain.Contracts
{
    public interface IEmployee
    {
        decimal Salary { get; set; }

        decimal AmountDue { get; set; }

        IAddress MailingAddress { get; set; }
    }
}
