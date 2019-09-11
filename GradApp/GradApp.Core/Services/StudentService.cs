using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public Student Add(Student Student)
        {
            _studentRepo.Add(Student);
            return Student;
        }

        public Student Get(int id)
        {
            return _studentRepo.Get(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepo.GetAll();
        }

        public Student Update(Student updatedStudent)
        {
            var Student = _studentRepo.Update(updatedStudent);
            return Student;
        }

        public void Remove(Student Student)
        {
            _studentRepo.Remove(Student);
        }
    }
}
