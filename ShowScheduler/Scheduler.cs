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

        private bool hasConflict = false;

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
            int timeoutCount = 0;

            while (shows.Count > 0)
            {
                for (int w = 0; w < WEEK; w++)
                {
                    for (int s = 0; s < SLOTS; s++)
                    {
                        Show show = Show.getShowForSlot(shows, w, s);
                        if (show != null)
                        {
                            Schedule[w, s] = Show.getShowForSlot(shows, w, s);

                        }
                        else
                            timeoutCount++;
                    }
                }
                if (timeoutCount >= WEEK * SLOTS)
                    hasConflict = true; // have list added to generated schedule for manual scheduling
                else timeoutCount = 0;
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
