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
        private List<Show> conflicts;

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

            shows = Show.GetShows();
            conflicts = new List<Show>();
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
                        Show show = Show.GetShowForSlot(shows, w, s + 9);
                        if (show != null)
                        {
                            Schedule[w, s] = show;
                        }
                    }
                }
                CheckForNoSlots();
            }
        }

        /// <summary>
        /// Moves any shows with the NoSlot flag to conficts list from shows list
        /// </summary>
        public void CheckForNoSlots()
        {
            for (int i = 0; i < shows.Count;)
            {
                if (shows[i].NoSlot)
                {
                    hasConflict = true;
                    conflicts.Add(shows[i]);
                    shows.RemoveAt(i);
                }
                else i++;
            }
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

            Generate();
            HTMLSchedule html = new HTMLSchedule(Schedule, hasConflict, conflicts);
            html.OutputResults();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pref"></param>
        /// <param name="show"></param>
        /// <returns></returns>
        private int[] getSlot(int pref, Show show)
        {
            return new int[] { show.GetTime() - 9, show.GetDay() };
        }
    }
}
