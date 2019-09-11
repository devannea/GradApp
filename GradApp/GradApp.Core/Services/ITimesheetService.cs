using System.Collections.Generic;
using GradApp.Core.Models;

namespace GradApp.Core.Services
{
    interface ITimesheetService
    {
        Timesheet Add(Timesheet Timesheet);
        Timesheet Get(int id);
        IEnumerable<Timesheet> GetAll();
        void Remove(Timesheet Timesheet);
        Timesheet Update(Timesheet updatedTimesheet);
    }
}