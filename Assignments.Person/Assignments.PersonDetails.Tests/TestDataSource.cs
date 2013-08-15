using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.PersonDetails.Domain;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Tests
{
    public class TestDataSource
    {
        public string ValidFName
        {
            get
            {
                return "Bhavin";
            }
        }

        public string InvalidFName
        {
            get
            {
                return "Bhavin15@";
            }
        }
        public string ValidLName
        {
            get
            {
                return "Thakkar";
            }
        }

        public string InvalidLName
        {
            get
            {
                return "Thakkar@#1";
            }
        }

        public DateTime ValidDOB
        {
            get
            {
                return (DateTime.Today.AddDays(-1));
            }
        }

        public DateTime FutureDOB
        {
            get
            {
                return (DateTime.Now.AddDays(1));
            }
        }
        public DateTime AdultDOB
        {
            get
            {
                return DateTime.Now.AddYears(-18);
            }
        }
        public DateTime TooOld
        {
            get
            {
                return (DateTime.Now.AddYears(-101));
            }
        }

        public DateTime BirthdayToday
        {
            get
            {
                return (DateTime.Now.AddYears(-55));
            }
        }
        public string InvalidEmailId
        {
            get
            {
                return "bthakkar@tavisca.com@44.ff";
            }
        }

        public string ValidEmailId
        {
            get
            {
                return "bthakkar@tavisca.com";
            }
        }

        public decimal ValidSalary
        {
            get
            {
                return 35000;
            }
        }

        public decimal ValidAdditionalPay
        {
            get
            {
                return (decimal)(35000 * 0.49);
            }
        }

        public IAddress ValidAddress = new Address()
        {
            AddressLine1 = "E-406 Ziggurat, Near Navale Bridge",
            AddressLine2 = "Katraj-Dehuroad bypass",
            City = "Pune",
            State = "Maharashtra",
            Country = "India",
            ZipCode = 411051
        };
    }
}
