using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    public class Show
    {
        public static List<string> Week = new List<string>()
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        public string Name { get; private set; }
        public List<int> Times { get; private set; }
        public List<int> Days { get; private set; }
        public int Tenure { get; private set; }
        public bool TwoHour { get; private set; }
        public string IssueReason { get; set; }

        public int StartTime
        {
            get { return Times[CurrentPreference]; }
        }

        public int EndTime
        {
            get { return TwoHour ? Times[CurrentPreference] + 2 : Times[CurrentPreference] + 1; }
        }

        public int Day
        {
            get { return Days[CurrentPreference]; }
        }

        public int CurrentPreference { get; set; }

        private static Dictionary<Regex, int> dayToInt = new Dictionary<Regex, int>()
        {
            { new Regex(@"\b", RegexOptions.Compiled | RegexOptions.IgnoreCase), 0 } // May not be needed
        };

        /// <summary>
        /// Constructs a radio show object and all its 'requirements'.
        /// </summary>
        /// <param name="name">Show name</param>
        /// <param name="times">Ordered list of preferred times of day (7 -> 23)</param>
        /// <param name="days">Ordered list of preferred days mapped 1:1 to times</param>
        /// <param name="tenure">Semesters of tenure the show has (or DJ)</param>
        /// <param name="twoHour">Is the show 1 or 2 hours?</param>
        public Show(string name, List<int> times, List<int> days, int tenure, bool twoHour)
        {
            Name = name;
            Times = times;
            Days = days;
            Tenure = tenure;
            TwoHour = twoHour;
            CurrentPreference = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "" + Name + ", " + Tenure + " semesters tenure, " + (TwoHour ? "Two Hour" : "One Hour") + "\n";
        }

        public static int DayStringToInt(string day)
        {
            return -1;
        }
    }
}
