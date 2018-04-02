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
        private Show[,] schedule;


        /// <summary>
        /// 
        /// </summary>
        public Scheduler()
        {
            // 14 hours a day
            // 0 = morning slot
            // 1 - 14 are time - 9 = idx (first slot is 10:00)
            schedule = new Show[7, 15]; // col x row
        }

        /// <summary>
        /// TODO: Needs to run asynchronously
        /// </summary>
        public void Schedule()
        {

        }
    }
}
