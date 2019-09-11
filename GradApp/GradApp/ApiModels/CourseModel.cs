using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradApp.ApiModels
{
    public class CourseModel
    {
        public int Id { get; set; }
        public int CourseCode { get; set; }
        public int CourseSection { get; set; }
        public string CourseName { get; set; }
        public string Subject { get; set; }
    }
}
