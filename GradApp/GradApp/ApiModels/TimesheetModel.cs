using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradApp.ApiModels
{
    public class TimesheetModel
    {
        public int Id { get; set; }
        public CourseModel Course { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        public string Initials { get; set; }
    }
}
