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
        public int WEEK = 7;
        public int SLOTS = 15;

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
                for (int w = 0; w < WEEK; w++)
                {
                    for (int s = 0; s < SLOTS; s++)
                    {
                        Schedule[w, s] = Show.getShowForSlot(shows, w, s);
                    }
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
            return new int[] { show.getTime() - 9, show.getDay() };
        }
    }
}
