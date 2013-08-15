using Assignments.PersonDetails.Domain;
using Assignments.PersonDetails.Domain.Contracts;
using Assignments.PersonDetails.Services;
using Assignments.PersonDetails.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.PersonDetails.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        public IPayable EmployeePaymentService=new EmployeePaymentService();
        public TestDataSource Data = new TestDataSource();

        public IEmployee CreateValidEmployee(decimal salary)
        {
            return new Employee(Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.ValidDOB, salary);
        }
        [TestMethod]
        public void RetrieveEntireAmountTest()
        {
            IEmployee employee = CreateValidEmployee(Data.ValidSalary);
            EmployeePaymentService.AddSalary(employee);
            EmployeePaymentService.AddSalary(employee);

            decimal amountRetrieved = EmployeePaymentService.RetrieveFullAmount(employee);

            Assert.AreEqual(employee.Salary*2,amountRetrieved);
            Assert.AreEqual(0, employee.AmountDue);
        }

        [TestMethod]
        public void RetrieveAmountTest()
        {
            IEmployee employee = CreateValidEmployee(Data.ValidSalary);

            EmployeePaymentService.AddAdditionalPay(Data.ValidAdditionalPay, employee);

            decimal amountRetrieved = EmployeePaymentService.RetrieveAmount(Data.ValidAdditionalPay, employee);
            Assert.AreEqual(Data.ValidAdditionalPay, amountRetrieved);
        }
        [TestMethod]
        public void ExceptionOnExcessiveRetrievalTest()
        {
            try
            {
                IEmployee employee = CreateValidEmployee(Data.ValidSalary);
                EmployeePaymentService.AddSalary(employee);
                EmployeePaymentService.AddSalary(employee);

                decimal amountRetrieved = employee.Salary * 3;
                EmployeePaymentService.RetrieveAmount(amountRetrieved,employee);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e,typeof(InvalidOperationException));
                Assert.AreEqual(ErrorMessages.InsufficientAmount, e.Message);
            }
        }

        [TestMethod]
        public void ExceptionOnExcessiveAdditionalPayTest()
        {
            try
            {
                IEmployee employee = CreateValidEmployee(Data.ValidSalary);
                EmployeePaymentService.AddAdditionalPay(Data.ValidAdditionalPay + 1, employee);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(InvalidOperationException));
                Assert.AreEqual(ErrorMessages.ExcessiveAdditionalPay, e.Message);
            }
        }

        [TestMethod]
        public void PaymentAddressTest()
        {
            IEmployee employee = CreateValidEmployee(Data.ValidSalary);
            EmployeePaymentService.SetPaymentAddress(Data.ValidAddress, employee);
            Assert.IsNotNull(employee.MailingAddress);
        }
    }
}
