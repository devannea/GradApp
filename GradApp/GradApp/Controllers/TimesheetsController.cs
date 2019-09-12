using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GradApp.ApiModels;
using GradApp.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradApp.Controllers
{
    [Route("api/[controller]")]
    public class TimesheetsController : ControllerBase
    {
        private ITimesheetService _timesheetService;
        public TimesheetsController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_timesheetService.GetAll().ToApiModels());
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var timesheet = _timesheetService.Get(id).ToApiModel();
            if (timesheet == null) return NotFound();
            return Ok(timesheet);
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] TimesheetModel timesheet)
        {
            try
            {
                _timesheetService.Add(timesheet.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddTimesheet", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = timesheet.Id }, timesheet);
        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TimesheetModel timesheet)
        {
            timesheet.Id = id;
            var tempTimesheet = _timesheetService.Update(timesheet.ToDomainModel());
            if (tempTimesheet == null) return NotFound();
            return Ok(tempTimesheet);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var timesheet = _timesheetService.Get(id);
            if (timesheet == null) return NotFound();
            _timesheetService.Remove(timesheet);
            return NoContent();
        }
    }
}
