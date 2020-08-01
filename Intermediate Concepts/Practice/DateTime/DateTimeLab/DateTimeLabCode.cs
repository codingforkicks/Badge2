using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            return DateTime.Today;
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            //use substring for year since year is passed as yyyy
            return $"{month}/{day}/{year.ToString().Substring(2)}";
        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            return DateTime.Parse(date);
        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            //create custom format for string output
            string format = "MM.dd.yyyy hh:mm tt";
            DateTime formattedDate = DateTime.Parse(date);
            return formattedDate.ToString(format);
        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            //create custom format for string output
            string format = "MMMM d, yyyy";
            DateTime currentDate = DateTime.Parse(date);
            DateTime futureDate = currentDate.AddMonths(6);
            return futureDate.ToString(format);
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            string format = "MMMM d, yyyy";
            DateTime currentDate = DateTime.Parse(date);
            DateTime pastDate = currentDate.AddDays(-30);
            return pastDate.ToString(format);
        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            //create array to store wednesdays and an index for while loop
            DateTime[] wednesdays = new DateTime[count];
            int index = 0;

            //record current date and determine its day of the week
            DateTime currentDate = DateTime.Parse(startDate);

            while(index < count)
            {
                //determine if current date is wednesday
                //if so add it to datetime array
                //if not find the next wednesday
                if(currentDate.DayOfWeek == DayOfWeek.Wednesday)
                {
                    wednesdays[index] = currentDate;
                    index++;
                }
                switch (currentDate.DayOfWeek)
                {
                    case DayOfWeek.Wednesday:
                        currentDate = currentDate.AddDays(7);
                        break;
                    default:
                        currentDate = currentDate.AddDays(1);
                        break;
                }
            }
            return wednesdays;
        }
    }
}
