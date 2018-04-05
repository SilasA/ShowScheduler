using System;
using System.Collections.Generic;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    public class Show
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

        /// <summary>
        /// 
        /// </summary>
        private int prefSlot;

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
            this.prefSlot = 0;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /*public override bool Equals(Show obj)
        {
            if (obj == null) return false;
            return ((Show)obj)?.getName() == getName();
        }*/

        #region Accessors/Mutators

        /// <summary>
        /// 
        /// </summary>
        public void nextPref() { prefSlot++; } // Handle rollover
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getPrefSlot() { return prefSlot; }

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
        /// <returns></returns>
        public int getTime()
        {
            if (prefSlot > 3) return -1;
            if (Dummy) return Parent.times[prefSlot];
            return times[prefSlot];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getDay()
        {
            if (prefSlot > 3) return -1;
            if (Dummy) return Parent.days[prefSlot];
            return days[prefSlot];
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shows"></param>
        /// <param name="day"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static Show getShowForSlot(List<Show> shows, int day, int slot)
        {
            List<Show> matches = new List<Show>();
            foreach (Show s in shows)
            {
                if (s.getDay() == day && s.getTime() == slot)
                {
                    matches.Add(s);
                }
            }
            matches.Sort((Show x, Show y) => y.getTenure() - x.getTenure());

            for (int i = 1; i < matches.Count; i++)
                matches[i].nextPref();

            shows.Remove(matches[0]);

            return matches[0];
        }
    }
}
