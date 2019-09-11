using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradApp.ApiModels;
using GradApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradApp.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll().ToApiModels());
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id).ToApiModel();
            if (student == null) return NotFound();
            return Ok(student);
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] StudentModel student)
        {
            try
            {
                _studentService.Add(student.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddStudent", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = student.Id }, student);
        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentModel student)
        {
            student.Id = id;
            var tempStudent = _studentService.Update(student.ToDomainModel());
            if (tempStudent == null) return NotFound();
            return Ok(tempStudent);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentService.Get(id);
            if (student == null) return NotFound();
            _studentService.Remove(student);
            return NoContent();
        }
    }
}
