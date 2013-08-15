using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments.PersonDetails.Domain.Contracts;

namespace Assignments.PersonDetails.Domain
{
    public class Person : IPerson
    {
        #region IPerson Members

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailId { get; set; }

        #endregion

        #region Read Only Properties

        public bool IsAdult
        {
            get
            {
                if (DateOfBirth != DateTime.MinValue)
                {
                    int age = DateTime.Now.Year - DateOfBirth.Year;
                    if (DateTime.Now.Month < DateOfBirth.Month ||
                        (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                        age--;
                    if (age >= 18)
                        return true;
                    else
                        return false;
                }
                else
                {
                    throw new ArgumentNullException(ErrorMessages.DOB);
                }
            }
        }

        public bool Birthday
        {
            get
            {
                if (DateOfBirth != DateTime.MinValue)
                {
                    if (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day == DateOfBirth.Day)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    throw new ArgumentNullException(ErrorMessages.DOB);
                }
            }
        }

        public string ScreenName
        {
            get
            {
                StringBuilder screenName = new StringBuilder();
                if (DateOfBirth != DateTime.MinValue)
                {
                    screenName.Append(FirstName.First());
                    screenName.Append(LastName.ToLowerInvariant());
                    screenName.Append(DateOfBirth.Day.ToString());
                    screenName.Append(DateOfBirth.Month.ToString());
                }
                else
                {
                    screenName.Append(EmailId);
                }
                return screenName.ToString();
            }
        }

        public string ZodiacSign
        {
            get
            {
                string zodiacSign = string.Empty;

                string[] longDate = DateOfBirth.ToLongDateString().Split(',');
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
        }

        #endregion

        public Person(string firstName, string lastName, string emailId, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailId = emailId;
            DateOfBirth = dateOfBirth;
            this.FirstName = firstName;
        }

        public Person(string firstName, string lastName, string emailId)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailId = emailId;
            DateOfBirth = DateTime.MinValue;
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
