using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechHoliday
{
    using NationalHolidayLib;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.GetMonthWorkingDaysCountForCzech());
        }
    }
}
