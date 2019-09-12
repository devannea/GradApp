using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Services
{
    public class TimesheetService : ITimesheetService
    {
        private ITimesheetRepository _timesheetRepo;

        public TimesheetService(ITimesheetRepository timesheetRepo)
        {
            _timesheetRepo = timesheetRepo;
        }

        public Timesheet Add(Timesheet Timesheet)
        {
            _timesheetRepo.Add(Timesheet);
            return Timesheet;
        }

        public Timesheet Get(int id)
        {
            return _timesheetRepo.Get(id);
        }

        public IEnumerable<Timesheet> GetAll()
        {
            return _timesheetRepo.GetAll();
        }

        public Timesheet Update(Timesheet updatedTimesheet)
        {
            var Timesheet = _timesheetRepo.Update(updatedTimesheet);
            return Timesheet;
        }

        public void Remove(Timesheet Timesheet)
        {
            _timesheetRepo.Remove(Timesheet);
        }
    }
}
