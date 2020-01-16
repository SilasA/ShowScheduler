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
        private Show[,] schedule;
        private bool hasConflict;
        private List<Show> conflicting;

        private StringWriter html;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="hasConflict"></param>
        /// <param name="shows"></param>
        public HTMLSchedule(Show[,] schedule, bool hasConflict, List<Show> conflicting)
        {
            this.schedule = schedule;
            this.hasConflict = hasConflict;
            this.conflicting = conflicting;

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

                for (int r = 0; r < schedule.GetLength(1); r++)
                {
                    h.RenderBeginTag(HtmlTextWriterTag.Tr);
                    h.RenderBeginTag(HtmlTextWriterTag.Td);
                    if (r == 0)
                        h.WriteLine("Morning Slot");
                    else
                        h.WriteLine((r + 9) + ":00");
                    h.RenderEndTag(); // Td
                    for (int c = 0; c < schedule.GetLength(0); c++)
                    {
                        h.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                        h.RenderBeginTag(HtmlTextWriterTag.Td);
                        h.WriteLine(schedule[c, r]?.GetName());
                        h.RenderEndTag(); // Td
                    }
                    h.RenderEndTag(); // Tr
                }

                h.RenderEndTag(); // Table

                // Conflicts
                if (hasConflict)
                {
                    // <table style="width:100%">
                    h.AddAttribute(HtmlTextWriterAttribute.Style, "width:20%;align:center;");
                    h.AddAttribute(HtmlTextWriterAttribute.Border, "1");
                    h.RenderBeginTag(HtmlTextWriterTag.Table);

                    // Header
                    h.RenderBeginTag(HtmlTextWriterTag.Tr);

                    h.RenderBeginTag(HtmlTextWriterTag.Th);
                    h.WriteLine("Conflicts");
                    h.RenderEndTag(); // Th

                    h.RenderEndTag(); // Tr

                    foreach (Show s in conflicting)
                    {
                        h.RenderBeginTag(HtmlTextWriterTag.Tr);

                        h.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                        h.RenderBeginTag(HtmlTextWriterTag.Td);
                        h.WriteLine(s.GetName());
                        h.RenderEndTag(); // Th

                        h.RenderEndTag(); // Tr
                    }

                    h.RenderEndTag(); // Table
                }
            }
        }
    }
}
