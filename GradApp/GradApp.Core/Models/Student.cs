using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradApp.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Timesheet> Timesheets { get; set; }
        //public TimeSpan TotalTime
        //{
        //    get
        //    {
        //        if (Timesheets != null)
        //            return Timesheets.ToList().Aggregate(TimeSpan.Zero, (memo, val) => memo.Add(val.ClockOut - val.ClockIn));
        //        else
        //            return new TimeSpan();
        //    }
        //    private set { }
        //}
    }
}