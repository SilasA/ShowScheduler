using System;
using System.Collections.Generic;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    class Show
    {
        public String Name { get; private set; }

        // time from 10 to 23
        private List<int> times;
        // day from 0 to 6 (0 monday)
        private List<int> days;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="day"></param>
        public Show(String name, List<int> time, List<int> day)
        {
            Name = name;
            times = time;
            days = day;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank">Preference of time (0 being prefered)</param>
        /// <returns></returns>
        public int getTime(int rank) { return times[rank]; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank">Preference of time (0 being prefered)</param>
        /// <returns></returns>
        public int getDay(int rank) { return days[rank]; }
    }
}
