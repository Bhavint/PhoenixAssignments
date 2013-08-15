using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.PersonDetails.Domain;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Services.Contracts
{
    public interface IValidatorService
    {
        IValidationResult Validate(string firstName, string lastName, string emailId, DateTime dateOfBirth);

        IValidationResult Validate(string firstName, string lastName, string emailId);

        IValidationResult Validate(string firstName, string lastName, DateTime dateOfBirth);
    }
}
