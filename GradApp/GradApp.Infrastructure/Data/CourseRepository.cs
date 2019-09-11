using GradApp.Core.Models;
using GradApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradApp.Infrastructure.Data
{
    class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course Add(Course Course)
        {
            _dbContext.Courses.Add(Course);
            _dbContext.SaveChanges();
            return Course;
        }
        public Course Get(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(u => u.Id == id);
            if (course == null) return null;
            return course;
        }
        public Course Update(Course updatedCourse)
        {
            var currentCourse = _dbContext.Courses.FirstOrDefault(u => u.Id == updatedCourse.Id);
            if (currentCourse == null) return null;

            _dbContext.Entry(currentCourse).CurrentValues.SetValues(updatedCourse);
            _dbContext.Update(currentCourse);
            _dbContext.SaveChanges();
            return currentCourse;
        }
        public void Remove(Course Course)
        {
            _dbContext.Courses.Remove(Course);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Course> GetAll()
        {
            return _dbContext.Courses.ToList();
        }
    }
}
