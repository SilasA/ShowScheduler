using System.Collections.Generic;
using System.IO;
using System.Web.UI;

namespace ShowScheduler
{
    /// <summary>
    /// 
    /// </summary>
    class HTMLSchedule
    {
        private List<Show> schedule;
        private List<Show> conflicting;
        private List<Show> issues;

        private StringWriter html;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="hasConflict"></param>
        /// <param name="shows"></param>
        public HTMLSchedule(List<Show> schedule, List<Show> conflicting, List<Show> issues)
        {
            this.schedule = schedule;
            this.conflicting = conflicting;
            this.issues = issues;

            html = new StringWriter();

            PoplulateSchedule();
        }


        public void OutputResults()
        {
            StreamWriter sw = new StreamWriter(new FileStream("schedule.htm", FileMode.Create));
            sw.WriteLine(html);
            sw.Close();

            System.Diagnostics.Process.Start("schedule.htm");
        }


        /// <summary>
        /// 
        /// </summary>
        private void PoplulateSchedule()
        {
            using (HtmlTextWriter h = new HtmlTextWriter(html))
            {
                // <table style="width:100%">
                h.AddAttribute(HtmlTextWriterAttribute.Style, "width:100%");
                h.AddAttribute(HtmlTextWriterAttribute.Border, "1");
                h.RenderBeginTag(HtmlTextWriterTag.Table);

                h.RenderBeginTag(HtmlTextWriterTag.Tr);

                h.AddAttribute(HtmlTextWriterAttribute.Style, "width:5%");
                h.RenderBeginTag(HtmlTextWriterTag.Th);
                h.WriteLine("Time");
                h.RenderEndTag(); // Th

                // Day headers
                foreach (string day in Show.Week)
                {
                    h.RenderBeginTag(HtmlTextWriterTag.Th);
                    h.WriteLine(day);
                    h.RenderEndTag(); // Th
                }

                h.RenderEndTag(); // Tr

                for (int r = Scheduler.SLOT_START; r <= Scheduler.CUTOFF; r++)
                {
                    h.RenderBeginTag(HtmlTextWriterTag.Tr);
                    h.RenderBeginTag(HtmlTextWriterTag.Td);
                    if (r == 7)
                        h.WriteLine("Morning Slot");
                    else
                        h.WriteLine(r % 24 + ":00");
                    h.RenderEndTag(); // Td
                    for (int c = 0; c < Scheduler.WEEK; c++)
                    {
                        if (schedule.Find(show => show.Day == c && show.StartTime == r - 1 && show.TwoHour) != null)
                            continue;
                        Show s = schedule.Find(show => show.Day == c && show.StartTime == r);
                        if (s == null)
                        {
                            h.RenderBeginTag(HtmlTextWriterTag.Td);
                            h.RenderEndTag(); // Td
                            continue;
                        }

                        


                        h.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                        h.AddAttribute(HtmlTextWriterAttribute.Rowspan, s.TwoHour ? "2" : "1");
                        h.RenderBeginTag(HtmlTextWriterTag.Td);
                        h.WriteLine(s.Name);
                        h.RenderEndTag(); // Td
                    }
                    h.RenderEndTag(); // Tr
                }

                h.RenderEndTag(); // Table

                // Conflicts or Issues
                if (conflicting.Count > 0 || issues.Count > 0)
                {
                    // <table style="width:100%">
                    h.AddAttribute(HtmlTextWriterAttribute.Style, "width:20%;align:center;");
                    h.AddAttribute(HtmlTextWriterAttribute.Border, "1");
                    h.RenderBeginTag(HtmlTextWriterTag.Table);

                    // Header
                    h.RenderBeginTag(HtmlTextWriterTag.Tr);

                    h.RenderBeginTag(HtmlTextWriterTag.Th);
                    h.WriteLine("Conflicts/Issues");
                    h.RenderEndTag(); // Th

                    h.RenderEndTag(); // Tr

                    foreach (Show s in conflicting)
                    {
                        h.RenderBeginTag(HtmlTextWriterTag.Tr);

                        h.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                        h.RenderBeginTag(HtmlTextWriterTag.Td);
                        h.WriteLine(s.Name + "\n" + s.IssueReason);
                        h.RenderEndTag(); // Th

                        h.RenderEndTag(); // Tr
                    }

                    foreach (Show s in issues)
                    {
                        h.RenderBeginTag(HtmlTextWriterTag.Tr);

                        h.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                        h.RenderBeginTag(HtmlTextWriterTag.Td);
                        h.WriteLine(s.Name + "\n" + s.IssueReason);
                        h.RenderEndTag(); // Th

                        h.RenderEndTag(); // Tr
                    }

                    h.RenderEndTag(); // Table
                }
            }
        }
    }
}
