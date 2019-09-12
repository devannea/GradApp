using GradApp.Core.Models;
using GradApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradApp.Infrastructure.Data
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly AppDbContext _dbContext;

        public TimesheetRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Timesheet Add(Timesheet Timesheet)
        {
            _dbContext.Timesheets.Add(Timesheet);
            _dbContext.SaveChanges();
            return Timesheet;
        }
        public Timesheet Get(int id)
        {
            var timesheet = _dbContext.Timesheets.FirstOrDefault(u => u.Id == id);
            if (timesheet == null) return null;
            return timesheet;
        }
        public Timesheet Update(Timesheet updatedTimesheet)
        {
            var currentTimesheet = _dbContext.Timesheets.FirstOrDefault(u => u.Id == updatedTimesheet.Id);
            if (currentTimesheet == null) return null;

            _dbContext.Entry(currentTimesheet).CurrentValues.SetValues(updatedTimesheet);
            _dbContext.Update(currentTimesheet);
            _dbContext.SaveChanges();
            return currentTimesheet;
        }
        public void Remove(Timesheet Timesheet)
        {
            _dbContext.Timesheets.Remove(Timesheet);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Timesheet> GetAll()
        {
            return _dbContext.Timesheets.ToList();
        }
    }
}
