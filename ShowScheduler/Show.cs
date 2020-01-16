using System;
using System.Collections.Generic;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    public class Show
    {
        public static readonly List<string> Week = new List<string>()
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

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
        /// 
        /// </summary>
        public bool NoSlot { get; private set; }

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
        public void NextPref()
        {
            prefSlot++;
            if (prefSlot >= times.Count)
                NoSlot = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetPrefSlot() { return prefSlot; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetName()
        {
            if (Dummy) return Parent.name;
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTenure()
        {
            if (Dummy) return Parent.tenure;
            return tenure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTime()
        {
            if (NoSlot) return -1;
            if (prefSlot > 3) return -1;
            if (Dummy) return Parent.times[prefSlot] + 1;
            return times[prefSlot];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetDay()
        {
            if (NoSlot) return -1;
            if (prefSlot > 3) return -1;
            if (Dummy) return Parent.days[prefSlot];
            return days[prefSlot];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return GetName() + "\n " + Week[GetDay()] + " " + GetTime() + ":00";
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Show> GetShows()
        {
            Show s = new Show("test2", new List<int>() { 12, 14, 10 }, new List<int>() { 0, 1, 4 }, 2, false);

            return new List<Show>()
            {
                new Show("test1", new List<int>() { 12, 14, 10 }, new List<int>() { 0, 1, 4 }, 4, false),
                s, new Show(s),
                new Show("test8", new List<int>() { 12, 14, 10 }, new List<int>() { 0, 1, 4 }, 2, false),
                new Show("test9", new List<int>() { 12, 14, 10 }, new List<int>() { 0, 1, 4 }, 2, false),
                new Show("test3", new List<int>() { 22, 13, 9 }, new List<int>() { 0, 1, 4 }, 4, false),
                new Show("test4", new List<int>() { 12, 20, 10 }, new List<int>() { 1, 2, 3 }, 1, false),
                new Show("test5", new List<int>() { 19, 18, 10 }, new List<int>() { 0, 5, 3 }, 0, false),
                new Show("test6", new List<int>() { 20, 15, 10 }, new List<int>() { 2, 4, 1 }, 9, false),
                new Show("test7", new List<int>() { 0, 9, 10 }, new List<int>() { 0, 5, 6 }, 8, false)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shows"></param>
        /// <param name="day"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static Show GetShowForSlot(List<Show> shows, int day, int slot, bool twoHr)
        {
            List<Show> matches = new List<Show>();
            foreach (Show s in shows)
            {
                if (s.GetDay() == day && s.GetTime() == slot)
                {
                    matches.Add(s);
                }
            }
            if (!twoHr)
                matches.Sort((Show x, Show y) => y.GetTenure() - x.GetTenure());

            for (int i = 1; i < matches.Count; i++)
                matches[i].NextPref();

            if (matches.Count > 0)
                shows.Remove(matches[0]);

            for (int i = 0; i < matches.Count; i++)
            {
                if (twoHr && matches[i].Dummy && matches[i].GetDay() == day && matches[i].GetTime() == slot)
                    return matches[i];
            }

            return matches.Count > 0 ? matches[0] : null;
        }
    }
}
