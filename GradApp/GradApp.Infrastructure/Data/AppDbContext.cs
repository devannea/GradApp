using GradApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Infrastructure.Data
{
    class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=GradApp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                  new Student { Id = 1, StudentId = 123456789, FirstName = "Jane", LastName = "Doe" }
            );
            modelBuilder.Entity<Course>().HasData(
                  new Course { Id = 1, CourseCode = 1301, CourseSection = 201, CourseName = "MATH", Subject = "College Algebra" }
            );
            modelBuilder.Entity<Timesheet>().HasData(
                  new Timesheet { Id = 1, ClockIn = new DateTime(2019, 09, 04, 13, 32, 02), ClockOut = new DateTime(2019, 09, 04, 14, 17, 41), Initials = "HK" },
                  new Timesheet { Id = 2, ClockIn = new DateTime(2019, 09, 06, 12, 17, 37), ClockOut = new DateTime(2019, 09, 06, 13, 11, 21), Initials = "SW" },
                  new Timesheet { Id = 3, ClockIn = new DateTime(2019, 09, 09, 14, 03, 56), ClockOut = new DateTime(2019, 09, 09, 14, 47, 28), Initials = "DA" }
            );
        }
    }
}
