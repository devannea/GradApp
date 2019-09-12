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
    public class CoursesController : Controller
    {
        private ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_courseService.GetAll().ToApiModels());
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _courseService.Get(id).ToApiModel();
            if (course == null) return NotFound();
            return Ok(course);
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] CourseModel course)
        {
            try
            {
                _courseService.Add(course.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddCourse", ex.Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = course.Id }, course);
        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CourseModel course)
        {
            course.Id = id;
            var tempCourse = _courseService.Update(course.ToDomainModel());
            if (tempCourse == null) return NotFound();
            return Ok(tempCourse);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _courseService.Get(id);
            if (course == null) return NotFound();
            _courseService.Remove(course);
            return NoContent();
        }
    }
}
