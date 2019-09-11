using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Services
{
    public interface ICourseRepository
    {
        // Create
        Course Add(Course todo);
        // Read
        Course Get(int id);
        // Update
        Course Update(Course todo);
        // Delete
        void Remove(Course todo);
        // List
        IEnumerable<Course> GetAll();
    }
}
