using System;
using System.Threading;
using Assignments.PersonDetails.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Assignments.PersonDetails.Domain.Contracts;
using Assignments.PersonDetails.Services.Contracts;
using Assignments.PersonDetails.Services;
using System.Globalization;

namespace Assignments.PersonDetails.Tests
{
    [TestClass]
    public class PersonTests2
    {
        public TestDataSource Data = new TestDataSource();


        public string GetZodiacSign(DateTime dateOfBirth)
        {
            string zodiacSign = string.Empty;
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            string longdate = dateOfBirth.ToLongDateString();
            string[] longDate = dateOfBirth.ToLongDateString().Split(',');
            string[] monthAndDate = longDate[1].ToString().Split(' ');

            if (monthAndDate[1].ToString() == "March")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 20)
                    zodiacSign = "Pisces";
                else
                    zodiacSign = "Aries";
            }
            else if (monthAndDate[1].ToString() == "April")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 19)
                    zodiacSign = "Aries";
                else
                    zodiacSign = "Taurus";
            }
            else if (monthAndDate[1].ToString() == "May")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 20)
                    zodiacSign = "Taurus";
                else
                    zodiacSign = "Gemini";
            }
            else if (monthAndDate[1].ToString() == "June")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 20)
                    zodiacSign = "Gemini";
                else
                    zodiacSign = "Cancer";
            }
            else if (monthAndDate[1].ToString() == "July")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 22)
                    zodiacSign = "Cancer";
                else
                    zodiacSign = "Leo";
            }
            else if (monthAndDate[1].ToString() == "August")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 22)
                    zodiacSign = "Leo";
                else
                    zodiacSign = "Virgo";
            }
            else if (monthAndDate[1].ToString() == "September")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 22)
                    zodiacSign = "Virgo";
                else
                    zodiacSign = "Libra";
            }
            else if (monthAndDate[1].ToString() == "October")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 22)
                    zodiacSign = "Libra";
                else
                    zodiacSign = "Scorpio";
            }
            else if (monthAndDate[1].ToString() == "November")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 21)
                    zodiacSign = "Scorpio";
                else
                    zodiacSign = "Sagittarius";
            }
            else if (monthAndDate[1].ToString() == "December")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 21)
                    zodiacSign = "Sagittarius";
                else
                    zodiacSign = "Capricorn";
            }
            else if (monthAndDate[1].ToString() == "January")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 19)
                    zodiacSign = "Capricorn";
                else
                    zodiacSign = "Aquarius";
            }
            else if (monthAndDate[1].ToString() == "February")
            {
                if (Convert.ToInt32(monthAndDate[2]) <= 18)
                    zodiacSign = "Aquarius";
                else
                    zodiacSign = "Pisces";
            }
            return zodiacSign;
        }

        #region Creator
        public IPerson CreateTestPerson(IValidationResult result, IValidatorService validator, string firstName, string lastName, string emailId, DateTime dateOfBirth)
        {
            result = validator.Validate(firstName, lastName, emailId, dateOfBirth);
            if (result.IsSuccess == true)
            {
                return new Person(firstName, lastName, emailId, dateOfBirth);
            }
            else
            {
                throw new ValidationException() { Invalid = result.InvalidFields, };
            }
        }

        public IPerson CreateTestPerson(IValidationResult result, IValidatorService validator, string firstName, string lastName, string emailId)
        {
            result = validator.Validate(firstName, lastName, emailId);
            if (result.IsSuccess == true)
            {
                return new Person(firstName, lastName, emailId);
            }
            else
            {
                throw new ValidationException() { Invalid = result.InvalidFields, };
            }
        }

        public IPerson CreateTestPerson(IValidationResult result, IValidatorService validator, string firstName, string lastName, DateTime dateOfBirth)
        {
            result = validator.Validate(firstName, lastName, dateOfBirth);
            if (result.IsSuccess == true)
            {
                return new Person(firstName, lastName, dateOfBirth);
            }
            else
            {
                throw new ValidationException() { Invalid = result.InvalidFields, };
            }
        }
        #endregion

        //[TestInitialize]
        //public void Setup()
        //{
        //    IPerson person;
        //    IValidatorService validator = new ValidatorService();
        //    IValidationResult result = new ValidationResult();
        //}
        //[TestCleanup]
        //public void TearDown()
        //{
        //    //do nothing for now
        //}


        #region Tests
        /// <summary>
        /// Scenarios
        /// 1) Create with 4 parameters
        /// 2) Create with 3 parameters (First Name, Last Name, Email)
        /// 3) Create with 3 parameters (First Name, Last Name, DOB)
        /// </summary>
        [TestMethod]
        public void ValidPersonTest()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.ValidDOB);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidDOB);

        }

        /// <summary>
        /// Scenario
        /// 1) trying to create a person with invalid details -> Validation Exception Thrown
        /// </summary>
        [TestMethod]
        public void InvalidPersonTest()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();
            try
            {
                person = CreateTestPerson(result, validator, Data.InvalidFName, Data.InvalidLName, Data.TooOld);
                Assert.Fail();
            }
            catch (ValidationException e)
            {
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.LastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.InvalidLastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.FirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.InvalidFirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.DOB)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.DOBtooMuchinPast)));
            }
        }

        /// <summary>
        /// Tests for constructor with Null values
        /// </summary>
        [TestMethod]
        public void PersonWithNullValuesTest()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();
            try
            {
                person = CreateTestPerson(result, validator, String.Empty, String.Empty, String.Empty);
                Assert.Fail();
            }
            catch (ValidationException e)
            {
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.FirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingFirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.LastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingLastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.EmailId)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingEmailId)));
            }

            try
            {
                person = CreateTestPerson(result, validator, String.Empty, String.Empty, String.Empty, Data.TooOld);
                Assert.Fail();
            }
            catch (ValidationException e)
            {
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.FirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingFirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.LastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingLastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.EmailId)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingEmailId)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.DOB)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.DOBtooMuchinPast)));
            }
            try
            {
                person = CreateTestPerson(result, validator, String.Empty, String.Empty, Data.FutureDOB);
                Assert.Fail();
            }
            catch (ValidationException e)
            {
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.FirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingFirstName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.LastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.MissingLastName)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.DOB)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.FutureDOB)));
            }
        }

        [TestMethod]
        public void ExceptionOnInvalidEmailTest()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();
            try
            {
                person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.InvalidEmailId, Data.ValidDOB);
                Assert.Fail();
            }
            catch (ValidationException e)
            {
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.EmailId)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.InvalidEmailId)));
            }
        }

        [TestMethod]
        public void ExceptionOnFutureDateofBirth()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();
            try
            {
                person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.InvalidEmailId, Data.FutureDOB);
                Assert.Fail();
            }
            catch (ValidationException e)
            {
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.FieldName.Equals(ErrorMessages.DOB)));
                Assert.IsNotNull(e.Invalid.Find(invalid => invalid.Message.Equals(ErrorMessages.FutureDOB)));
            }
        }

        //Pending REFACTOR
        /// <summary>
        /// scenarios:
        /// 1)True
        /// 2)False
        /// 3)DOB not Provided -> (ArgumentNullException)
        /// </summary>
        [TestMethod]
        public void BirthdayTest()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.BirthdayToday);
            Assert.IsTrue(person.Birthday);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.BirthdayToday.AddDays(1));
            Assert.IsFalse(person.Birthday);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.BirthdayToday.AddMonths(-1));
            Assert.IsFalse(person.Birthday);

            try
            {
                person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId);
                Assert.IsFalse(person.Birthday);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }

        }

        //Pending REFACTOR
        /// <summary>////////////
        /// scenarios:
        /// 1)True
        /// 2)False
        /// 3)DOB not provided -> ArgumentNullException
        /// </summary>
        [TestMethod]
        public void IsAdultTest()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.AdultDOB);
            Assert.IsTrue(person.IsAdult);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.AdultDOB.AddMonths(1));
            Assert.IsFalse(person.IsAdult);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.AdultDOB.AddDays(1));
            Assert.IsFalse(person.IsAdult);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId, Data.AdultDOB.AddMonths(-1));
            Assert.IsTrue(person.IsAdult);

            try
            {
                person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId);
                Assert.IsFalse(person.IsAdult);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }
        }

        //Pending REFACTOR
        /// <summary>
        /// Scenarios
        /// 1) DOB Not Provided -> (email Id becomes Screen Name)
        /// 2) DOB provided -> (Screen Name of form 'FirstChar'+"Surname"+Day+Month
        /// </summary>
        [TestMethod]
        public void ScreenNameTest()
        {
            IPerson person;
            IValidatorService validator = new ValidatorService();
            IValidationResult result = new ValidationResult();

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidEmailId);
            Assert.AreEqual(Data.ValidEmailId, person.ScreenName);

            person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, Data.ValidDOB);

            StringBuilder screenName = new StringBuilder();
            screenName.Append(Data.ValidFName[0]);
            screenName.Append(Data.ValidLName.ToLowerInvariant());
            screenName.Append(Data.ValidDOB.Day.ToString());
            screenName.Append(Data.ValidDOB.Month.ToString());

            Assert.AreEqual(screenName.ToString(), person.ScreenName);
        }

        //Pending REFACTOR
        /// <summary>
        /// Scenarios
        /// 1) Day of Month before 19-22 dates
        /// 2) Day of the Month after 19-22 dates
        /// </summary>
        /// DEFAULT ENVIRONMENT en-IN AT HOME en-US in OFFICE!!!
        [TestMethod]
        public void ZodiacSignTest()
        {
            for (int month = 1; month <= 12; month++)
            {
                IPerson person;
                IValidatorService validator = new ValidatorService();
                IValidationResult result = new ValidationResult();

                person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, new DateTime(1991, month, 15));
                Assert.AreEqual(GetZodiacSign(new DateTime(1991, month, 15)), person.ZodiacSign);

                person = CreateTestPerson(result, validator, Data.ValidFName, Data.ValidLName, new DateTime(1991, month, 27));
                Assert.AreEqual(GetZodiacSign(new DateTime(1991, month, 27)), person.ZodiacSign);

            }
        }
        #endregion
    }
}
