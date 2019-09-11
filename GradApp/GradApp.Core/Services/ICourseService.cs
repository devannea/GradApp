using System.Collections.Generic;
using GradApp.Core.Models;

namespace GradApp.Core.Services
{
    public interface ICourseService
    {
        Course Add(Course Course);
        Course Get(int id);
        IEnumerable<Course> GetAll();
        void Remove(Course Course);
        Course Update(Course updatedCourse);
    }
}