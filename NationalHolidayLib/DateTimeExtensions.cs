using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalHolidayLib
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsCzechHoliday(this DateTime date)
        {
            bool isCzechHoliday = true;

            //  1. ledna - Den obnovy samostatného českého státu
            if (date.Day == 1 && date.Month == 1) { }
            // 1. května – Svátek práce
            else if (date.Day == 1 && date.Month == 5) { }
            //  8. května - Den vítězství 
            else if (date.Day == 8 && date.Month == 5) { }
            // 5.července – Den slovanských věrozvěstů Cyrila a Metoděje 
            else if (date.Day == 5 && date.Month == 7) { }
            // 6.července – Den upálení mistra Jana Husa
            else if (date.Day == 6 && date.Month == 7) { }
            // 28. září – Den české státnosti 
            else if (date.Day == 28 && date.Month == 9) { }
            // 28. října – Den vzniku samostatného československého státu 
            else if (date.Day == 28 && date.Month == 10) { }
            // 17. listopadu – Den boje za svobodu a demokracii 
            else if (date.Day == 17 && date.Month == 11) { }
            // Vánoce
            else if (date.Day >= 24 && date.Day <= 26 && date.Month == 12) { }
            else
            {
                isCzechHoliday = false;
            }

            return isCzechHoliday;
        }

        public static bool IsCzechWorkingDay(this DateTime dateTime)
        {
            // isnt weekend and or is holiday
            return !IsWeekend(dateTime) && !IsCzechHoliday(dateTime);
        }

        /// <summary>
        /// Calculates working days from month got from <see cref="dateTime"/> parameter.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int GetMonthWorkingDaysCountForCzech(this DateTime dateTime)
        {
            DateTime firstDay = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime lastDay = new DateTime(dateTime.Year, dateTime.Month + 1, 1).AddDays(-1);

            int count = 0;
            for (DateTime day = firstDay; day <= lastDay; day = day.AddDays(1))
            {
                if (day.IsCzechWorkingDay())
                {
                    count++;
                }
            }

            return count;
        }
    }
}
