using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Services
{
    public class ValidationException : Exception, IValidationException
    {
        public List<IErrorMessage> Invalid { get; set; }
    }
}
