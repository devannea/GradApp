using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradApp.ApiModels
{
    public static class CourseMappingExtensions
    {
        public static CourseModel ToApiModel(this Course Course)
        {
            return new CourseModel
            {
                Id = Course.Id,
                CourseCode = Course.CourseCode,
                CourseSection = Course.CourseSection,
                CourseName = Course.CourseName,
                Subject = Course.Subject
            };
        }
        public static Course ToDomainModel(this CourseModel CourseModel)
        {
            return new Course
            {
                Id = CourseModel.Id,
                CourseCode = CourseModel.CourseCode,
                CourseSection = CourseModel.CourseSection,
                CourseName = CourseModel.CourseName,
                Subject = CourseModel.Subject
            };
        }
        public static IEnumerable<CourseModel> ToApiModels(this IEnumerable<Course> Courses)
        {
            if (Courses == null) return null;
            return Courses.Select(u => u.ToApiModel()).ToList();
        }
        public static IEnumerable<Course> ToDomainModels(this IEnumerable<CourseModel> CourseModels)
        {
            if (CourseModels == null) return null;
            return CourseModels.Select(u => u.ToDomainModel()).ToList();
        }
    }
}
