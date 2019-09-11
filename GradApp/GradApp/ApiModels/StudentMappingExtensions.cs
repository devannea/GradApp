using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradApp.ApiModels
{
    public static class StudentMappingExtensions
    {
        public static StudentModel ToApiModel(this Student Student)
        {
            return new StudentModel
            {
                Id = Student.Id,
                StudentId = Student.StudentId,
                FirstName = Student.FirstName,
                LastName = Student.LastName,
                //Timesheets = Student.Timesheets,
                //TotalTime = Student.TotalTime
            };
        }
        public static Student ToDomainModel(this StudentModel StudentModel)
        {
            return new Student
            {
                Id = StudentModel.Id,
                StudentId = StudentModel.StudentId,
                FirstName = StudentModel.FirstName,
                LastName = StudentModel.LastName,
                //Timesheets = StudentModel.Timesheets,
                //TotalTime = StudentModel.TotalTime
            };
        }
        public static IEnumerable<StudentModel> ToApiModels(this IEnumerable<Student> Students)
        {
            if (Students == null) return null;
            return Students.Select(u => u.ToApiModel()).ToList();
        }
        public static IEnumerable<Student> ToDomainModels(this IEnumerable<StudentModel> StudentModels)
        {
            if (StudentModels == null) return null;
            return StudentModels.Select(u => u.ToDomainModel()).ToList();
        }
    }
}
