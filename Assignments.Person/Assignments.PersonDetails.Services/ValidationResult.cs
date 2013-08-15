using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Services
{
    public class ValidationResult : IValidationResult
    {
        public bool IsSuccess
        {
            get
            {
                return InvalidFields.Count == 0;
            }
        }

        private List<IErrorMessage> _invalidFields = null;

        public List<IErrorMessage> InvalidFields
        {
            get
            {
                if (_invalidFields == null)
                    _invalidFields = new List<IErrorMessage>();
                return _invalidFields;
            }
        }
    }
}
