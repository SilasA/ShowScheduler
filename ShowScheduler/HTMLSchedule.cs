using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Text;
using System.Threading.Tasks;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    class HTMLSchedule
    {
        private Show[,] schedule;
        private List<Show> shows;
        private bool hasConflict;

        private StringWriter html;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="hasConflict"></param>
        /// <param name="shows"></param>
        public HTMLSchedule(Show[,] schedule, bool hasConflict, List<Show> shows)
        {
            this.schedule = schedule;
            this.hasConflict = hasConflict;
            this.shows = shows;

            html = new StringWriter();

            poplulateSchedule();
        }

        /// <summary>
        /// 
        /// </summary>
        private void poplulateSchedule()
        {
            using (HtmlTextWriter h = new HtmlTextWriter(html))
            {
                h.
            }
        }
    }
}
