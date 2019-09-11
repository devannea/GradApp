using GradApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradApp.Core.Services
{
    public interface ITimesheetRepository
    {
        // Create
        Timesheet Add(Timesheet todo);
        // Read
        Timesheet Get(int id);
        // Update
        Timesheet Update(Timesheet todo);
        // Delete
        void Remove(Timesheet todo);
        // List
        IEnumerable<Timesheet> GetAll();
    }
}
