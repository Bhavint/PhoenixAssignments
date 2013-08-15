using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignments.PersonDetails.Services.Contracts;
using Assignments.PersonDetails.Domain.Contracts;
using System.Text.RegularExpressions;
using Assignments.PersonDetails.Domain;

namespace Assignments.PersonDetails.Services
{
    public class ValidatorService : IValidatorService
    {
        public IValidationResult Validate(string firstName, string lastName, string emailId, DateTime dateOfBirth)
        {
            IValidationResult result = new ValidationResult();

            if (String.IsNullOrEmpty(firstName))
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.FirstName, Message = ErrorMessages.MissingFirstName });
            if (Regex.IsMatch(firstName, @"^[\p{L} \.\'\-]+$") == false)
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.FirstName, Message = ErrorMessages.InvalidFirstName });
            if (String.IsNullOrEmpty(lastName))
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.LastName, Message = ErrorMessages.MissingLastName });
            if (Regex.IsMatch(lastName, @"^[\p{L} \.\'\-]+$") == false)
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.LastName, Message = ErrorMessages.InvalidLastName });
            if (String.IsNullOrEmpty(emailId))
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.EmailId, Message = ErrorMessages.MissingEmailId });
            if (Regex.IsMatch(emailId, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$") == false)
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.EmailId, Message = ErrorMessages.InvalidEmailId });
            if (DateTime.Now - dateOfBirth < TimeSpan.Zero)
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.DOB, Message = ErrorMessages.FutureDOB });
            if (DateTime.Now - dateOfBirth > new TimeSpan(36500, 0, 0, 0))
                result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.DOB, Message = ErrorMessages.DOBtooMuchinPast });

            return result;
        }

        public IValidationResult Validate(string firstName, string lastName, string emailId)
        {
            {
                IValidationResult result = new ValidationResult();

                if (String.IsNullOrEmpty(firstName))
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.FirstName, Message = ErrorMessages.MissingFirstName });
                if (Regex.IsMatch(firstName, @"^[\p{L} \.\'\-]+$") == false)
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.FirstName, Message = ErrorMessages.InvalidFirstName });
                if (String.IsNullOrEmpty(lastName))
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.LastName, Message = ErrorMessages.MissingLastName });
                if (Regex.IsMatch(lastName, @"^[\p{L} \.\'\-]+$") == false)
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.LastName, Message = ErrorMessages.InvalidLastName });
                if (String.IsNullOrEmpty(emailId))
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.EmailId, Message = ErrorMessages.MissingEmailId });
                if (Regex.IsMatch(emailId, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b") == false)
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.EmailId, Message = ErrorMessages.InvalidEmailId });

                return result;
            }
        }

        public IValidationResult Validate(string firstName, string lastName, DateTime dateOfBirth)
        {
            {
                IValidationResult result = new ValidationResult();

                if (String.IsNullOrEmpty(firstName))
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.FirstName, Message = ErrorMessages.MissingFirstName });
                if (Regex.IsMatch(firstName, @"^[\p{L} \.\'\-]+$") == false)
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.FirstName, Message = ErrorMessages.InvalidFirstName });
                if (String.IsNullOrEmpty(lastName))
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.LastName, Message = ErrorMessages.MissingLastName });
                if (Regex.IsMatch(lastName, @"^[\p{L} \.\'\-]+$") == false)
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.LastName, Message = ErrorMessages.InvalidLastName });
                if (DateTime.Now - dateOfBirth < TimeSpan.Zero)
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.DOB, Message = ErrorMessages.FutureDOB });
                if (DateTime.Now - dateOfBirth > new TimeSpan(36500, 0, 0, 0))
                    result.InvalidFields.Add(new ErrorMessage { FieldName = ErrorMessages.DOB, Message = ErrorMessages.DOBtooMuchinPast });

                return result;
            }
        }
    }
}
