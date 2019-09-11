using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int CourseCode { get; set; }
        public int CourseSection { get; set; }
        public string CourseName { get; set; }
        public string Subject { get; set; }
    }
}
