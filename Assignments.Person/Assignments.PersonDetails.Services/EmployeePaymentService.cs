using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignments.PersonDetails.Services.Contracts;
using Assignments.PersonDetails.Domain;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Services
{
    public class EmployeePaymentService : IPayable
    {

        public void SetPaymentAddress(IAddress address,IEmployee employee)
        {
            employee.MailingAddress = address;
        }

        public decimal RetrieveFullAmount(IEmployee employee)
        {
            decimal returnValue = employee.AmountDue;
            employee.AmountDue = 0;
            return returnValue;
        }

        public void AddSalary(IEmployee employee)
        {
            employee.AmountDue += employee.Salary;
        }

        public void AddAdditionalPay(decimal additionalPay, IEmployee employee)
        {
            if (additionalPay <= employee.Salary * (decimal)0.49)
            {
                employee.AmountDue += additionalPay;
            }
            else
            {
                throw new InvalidOperationException(ErrorMessages.ExcessiveAdditionalPay);
            }

        }

        public decimal RetrieveAmount(decimal amount, IEmployee employee)
        {

            if (amount <= employee.AmountDue)
            {
                employee.AmountDue -= amount;
                return amount;
            }
            else
            {
                throw new InvalidOperationException(ErrorMessages.InsufficientAmount);
            }
            
        }
    }
}
