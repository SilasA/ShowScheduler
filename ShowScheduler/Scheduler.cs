using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    class Scheduler
    {
        public Show[,] Schedule { get; private set; }

        private List<Show> shows;

        /// <summary>
        /// 
        /// </summary>
        public Scheduler()
        {
            // 14 hours a day
            // 0 = morning slot
            // 1 - 14 are time - 9 = idx (first slot is 10:00)
            Schedule = new Show[7, 15]; // col x row

            shows = Show.getShows();
        }

        /// <summary>
        /// TODO: Needs to run asynchronously
        /// </summary>
        public void Generate()
        {
            while (shows.Count > 0)
            {
                int pref = 0;
                int[] slot = getSlot(pref, shows[0]);
                if (Schedule[slot[0], slot[1]] == null)
                {
                    Schedule[slot[0], slot[1]] = shows[0];
                    if (shows[0].TwoHour)
                    {
                        shows.RemoveAt(0);
                        Schedule[slot[0], slot[1] + 1] = shows[0];
                    }
                    shows.RemoveAt(0);
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pref"></param>
        /// <param name="show"></param>
        /// <returns></returns>
        private int[] getSlot(int pref, Show show)
        {
            return new int[] { show.getTime(pref) - 9, show.getDay(pref) };
        }
    }
}
