using Microsoft.AspNetCore.Mvc;
using SchoolApi.Repositories;
using SchoolDatabase.Models;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repo;

        public TeachersController(ITeacherRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _repo.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _repo.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            var newTeacher = await _repo.AddAsync(teacher);
            return CreatedAtAction(nameof(GetById), new { id = newTeacher.TeacherId }, newTeacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Teacher teacher)
        {
            var updated = await _repo.UpdateAsync(id, teacher);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
