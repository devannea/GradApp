using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Services
{
    public interface IStudentRepository
    {
        // Create
        Student Add(Student todo);
        // Read
        Student Get(int id);
        // Update
        Student Update(Student todo);
        // Delete
        void Remove(Student todo);
        // List
        IEnumerable<Student> GetAll();
    }
}
