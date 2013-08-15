using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Services
{
    public class ErrorMessage : IErrorMessage
    {
        public string FieldName { get; set; }

        public string Message { get; set; }
    }
}
