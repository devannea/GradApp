using System.Collections.Generic;
using GradApp.Core.Models;

namespace GradApp.Core.Services
{
    public interface IStudentService
    {
        Student Add(Student Student);
        Student Get(int id);
        IEnumerable<Student> GetAll();
        void Remove(Student Student);
        Student Update(Student updatedStudent);
    }
}