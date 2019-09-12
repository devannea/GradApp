using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Models
{
    public class Timesheet
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        public string Initials { get; set; }
    }
}
