using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradApp.ApiModels
{
    public class StudentModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<TimesheetModel> Timesheets { get; set; }
        public TimeSpan TotalTime
        {
            get
            {
                return Timesheets.ToList().Aggregate(TimeSpan.Zero, (memo, val) => memo.Add(val.ClockOut - val.ClockIn));
            }
            private set { }
        }
    }
}
