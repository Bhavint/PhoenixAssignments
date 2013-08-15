using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignments.PersonDetails.Domain;
using Assignments.PersonDetails.Domain.Contracts;


namespace Assignments.PersonDetails.Services.Contracts
{
    public interface IPayable
    {
        Decimal RetrieveFullAmount(IEmployee employee);

        Decimal RetrieveAmount(Decimal amount, IEmployee employee);

        void AddAdditionalPay(decimal additionalPay, IEmployee employee);

        void AddSalary(IEmployee employee);

        void SetPaymentAddress(IAddress address,IEmployee employee);
    }
}
