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
        public const int SLOT_START = 7;
        public const int SLOT_END = 23;
        public const int CUTOFF = 24; // Oof

        public List<Show> Schedule { get; private set; }

        private List<Show> shows;
        private List<Show> conflicts;
        private List<Show> issues;

        public bool Generated { get; private set; }
        public bool HasConflicts { get; private set; }
        public bool HasIssues { get; private set; }

        public Scheduler()
        {

        }

        public void FetchShows()
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

            Generate(true);
            HTMLSchedule html = new HTMLSchedule(Schedule, HasConflicts, conflicts);
        }

        public void Generate(bool useTenure)
        {
            if (useTenure)
                GenerateWithTenure();
            else
                GenerateWithoutTenure();
        }

        private void GenerateWithTenure()
        {
            shows.OrderByDescending(show => show.Tenure);

            while (shows.Count > 0)
            {
                for (int i = 0; i < shows.Count; i++)
                {
                    if (VerifyPreferences(shows[i]))
                    {
                        if (Schedule.Find(show => (
                            show.Day == shows[i].Day &&
                            show.StartTime >= shows[i].StartTime &&
                            show.EndTime <= shows[i].EndTime)) == null)
                        {
                            Schedule.Add(shows[i]);
                            shows.RemoveAt(i);
                            i--; // I have no excuses
                        }
                        else
                            shows[i].CurrentPreference++;
                    }
                    else if (shows[i].CurrentPreference >= 3)
                    {
                        HasConflicts = true;
                        shows[i].IssueReason = "No preferred times fit in the schedule.";
                        conflicts.Add(shows[i]);
                        shows.RemoveAt(i);
                        i--; // I have no excuses
                    }
                    else
                    {
                        HasIssues = true;
                        shows[i].IssueReason = "Issue: Likely invalid time or day";
                        issues.Add(shows[i]);
                        shows.RemoveAt(i);
                        i--; // I have no excuses
                    }
                }
            }
        }

        private void GenerateWithoutTenure()
        {

        }

        private bool VerifyPreferences(Show show)
        {
            return show.CurrentPreference < 3 &&
                show.Day > 0 && show.Day <= WEEK &&
                show.StartTime >= SLOT_START && show.StartTime <= SLOT_END &&
                show.EndTime >= SLOT_START && show.EndTime <= SLOT_END;
        }
    }
}
