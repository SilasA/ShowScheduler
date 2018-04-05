using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    class Scheduler
    {
        public const int WEEK = 7;
        public const int SLOTS = 15;

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

            // Open generated schedule form

        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowGenerated()
        {
            Show[,] s = new Show[7, 15]
            {
                { new Show("test1", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 4, false), null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                { new Show("test2", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 4, false), null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                { new Show("test3", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 4, false), null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                { new Show("test4", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 4, false), null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                { new Show("test5", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 4, false), null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                { new Show("test6", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 4, false), null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                { new Show("test7", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 4, false), null, null, null, null, null, null, null, null, null, null, null, null, null, null }
            };

            new Schedule(s, true, new List<Show>() { new Show("test8", new List<int>() { 12, 2, 10 }, new List<int>() { 0, 1, 4 }, 1, false) }).Show();
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
