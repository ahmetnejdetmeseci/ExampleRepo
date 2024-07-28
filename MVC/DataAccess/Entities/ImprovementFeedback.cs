using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ImprovementFeedback
    {
        public int ImprovementFeedbackId { get; set; }
        public string Feedback { get; set; }
        public DateTime DateSubmitted { get; set; }

        #region employee
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        #endregion

        #region machine
        public int? MachineId { get; set; }
        public Machine Machine { get; set; }
        #endregion

        #region process
        public int? ProcessId { get; set; }
        public Process Process { get; set; }
        #endregion

        #region feedback category
        public int FeedbackCategoryId { get; set; }
        public FeedbackCategory FeedbackCategory { get; set; }
        #endregion

    }
}
