using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.PersonDetails.Domain.Contracts
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        DateTime DateOfBirth { get; set; }

        string EmailId { get; set; }

        bool IsAdult { get; }

        bool Birthday { get; }

        string ScreenName { get; }

        string ZodiacSign { get; }
    }
}
