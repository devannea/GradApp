using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepo;

        public CourseService(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public Course Add(Course Course)
        {
            _courseRepo.Add(Course);
            return Course;
        }

        public Course Get(int id)
        {
            return _courseRepo.Get(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepo.GetAll();
        }

        public Course Update(Course updatedCourse)
        {
            var Course = _courseRepo.Update(updatedCourse);
            return Course;
        }

        public void Remove(Course Course)
        {
            _courseRepo.Remove(Course);
        }
    }
}
