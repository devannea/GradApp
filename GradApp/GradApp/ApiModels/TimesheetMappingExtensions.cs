using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradApp.ApiModels
{
    public static class TimesheetMappingExtensions
    {
        public static TimesheetModel ToApiModel(this Timesheet Timesheet)
        {
            return new TimesheetModel
            {
                Id = Timesheet.Id,
                //Course = Timesheet.Course,
                ClockIn = Timesheet.ClockIn,
                ClockOut = Timesheet.ClockOut,
                Initials = Timesheet.Initials
            };
        }
        public static Timesheet ToDomainModel(this TimesheetModel TimesheetModel)
        {
            return new Timesheet
            {
                Id = TimesheetModel.Id,
                //Course = TimesheetModel.Course,
                ClockIn = TimesheetModel.ClockIn,
                ClockOut = TimesheetModel.ClockOut,
                Initials = TimesheetModel.Initials
            };
        }
        public static IEnumerable<TimesheetModel> ToApiModels(this IEnumerable<Timesheet> Timesheets)
        {
            if (Timesheets == null) return null;
            return Timesheets.Select(u => u.ToApiModel()).ToList();
        }
        public static IEnumerable<Timesheet> ToDomainModels(this IEnumerable<TimesheetModel> TimesheetModels)
        {
            if (TimesheetModels == null) return null;
            return TimesheetModels.Select(u => u.ToDomainModel()).ToList();
        }
    }
}
