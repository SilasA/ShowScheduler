using System;
using System.Collections.Generic;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    class Show
    {
        /// <summary>
        /// If the show is a 2 hour show
        /// </summary>
        public bool TwoHour { get; private set; }

        /// <summary>
        /// If this is a dummy show (for 2 hr shows)
        /// </summary>
        public bool Dummy { get; private set; }

        /// <summary>
        /// Parent show if this is a dummy
        /// </summary>
        public Show Parent { get; private set; }

        /// <summary>
        /// Title of the Show
        /// </summary>
        private String name;

        /// <summary>
        /// Semesters in the org.
        /// </summary>
        private int tenure;

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
        public Show(String name, List<int> time, List<int> day, int tenure, bool twoHour)
        {
            this.name = name;
            this.tenure = tenure;
            this.times = time;
            this.days = day;
            TwoHour = twoHour;
            Dummy = false;
            Parent = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public Show(Show parent)
        {
            Dummy = true;
            Parent = parent;
            TwoHour = true;
        }

        #region Accessors

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            if (Dummy) return Parent.name;
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getTenure()
        {
            if (Dummy) return Parent.tenure;
            return tenure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank">Preference of time (0 being preferred)</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <returns></returns>
        public int getTime(int rank)
        {
            if (Dummy) return Parent.times[rank];
            return times[rank];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank">Preference of time (0 being preferred)</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <returns></returns>
        public int getDay(int rank)
        {
            if (Dummy) return Parent.days[rank];
            return days[rank];
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Show> getShows()
        {
            return new List<Show>();
        }
    }
}
