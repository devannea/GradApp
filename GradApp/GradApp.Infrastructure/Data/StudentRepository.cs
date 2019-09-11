using GradApp.Core.Models;
using GradApp.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradApp.Infrastructure.Data
{
    class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student Add(Student Student)
        {
            _dbContext.Students.Add(Student);
            _dbContext.SaveChanges();
            return Student;
        }
        public Student Get(int id)
        {
            var student = _dbContext.Students
                .Include(s => s.Timesheets)
                .ThenInclude(timesheet => timesheet.Course)
                .FirstOrDefault(u => u.Id == id);
            if (student == null) return null;
            return student;
        }
        public Student Update(Student updatedStudent)
        {
            var currentStudent = _dbContext.Students.FirstOrDefault(u => u.Id == updatedStudent.Id);
            if (currentStudent == null) return null;

            _dbContext.Entry(currentStudent).CurrentValues.SetValues(updatedStudent);
            _dbContext.Update(currentStudent);
            _dbContext.SaveChanges();
            return currentStudent;
        }
        public void Remove(Student Student)
        {
            _dbContext.Students.Remove(Student);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }
    }
}
