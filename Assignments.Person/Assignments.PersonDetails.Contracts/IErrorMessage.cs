using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.PersonDetails.Domain.Contracts
{
    public interface IErrorMessage
    {
        string FieldName { get; set; }

        string Message { get; set; }
    }
}
