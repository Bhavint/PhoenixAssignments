using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Domain
{
    public class Employee : Person, IEmployee
    {
        private decimal _salary;

        public decimal Salary { get { return _salary; } set { _salary = value; } }

        private decimal _amountDue;

        public decimal AmountDue { get { return _amountDue; } set { _amountDue = value; } }

        private IAddress _mailingAddress = null;

        public IAddress MailingAddress
        {
            get
            {
                return _mailingAddress;
            }
            set
            {
                if (_mailingAddress == null)
                    _mailingAddress = new Address();
                _mailingAddress = value;
            }
        }

        public Employee(string firstName, string lastName, string emailid, DateTime dateofBirth, decimal salary)
            : base(firstName, lastName, emailid, dateofBirth)
        {
            Salary = salary;
        }
    }
}
