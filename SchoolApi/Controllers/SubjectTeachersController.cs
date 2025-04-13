using Microsoft.AspNetCore.Mvc;
using SchoolDatabase.Models;
using SchoolApi.Repositories;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectTeachersController : ControllerBase
    {
        private readonly ISubjectTeacherRepository _repository;

        public SubjectTeachersController(ISubjectTeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjectTeachers = await _repository.GetAllAsync();
            return Ok(subjectTeachers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectTeacher subjectTeacher)
        {
            await _repository.AddAsync(subjectTeacher);
            return CreatedAtAction(nameof(GetByIds), new { subjectId = subjectTeacher.SubjectId, teacherId = subjectTeacher.TeacherId }, subjectTeacher);
        }

        [HttpGet("{subjectId}/{teacherId}")]
        public async Task<IActionResult> GetByIds(int subjectId, int teacherId)
        {
            var subjectTeacher = await _repository.GetByIdsAsync(subjectId, teacherId);
            if (subjectTeacher == null)
                return NotFound();
            return Ok(subjectTeacher);
        }

        [HttpPut("{subjectId}/{teacherId}")]
        public async Task<IActionResult> Update(int subjectId, int teacherId, SubjectTeacher subjectTeacher)
        {
            if (subjectId != subjectTeacher.SubjectId || teacherId != subjectTeacher.TeacherId)
                return BadRequest();

            await _repository.UpdateAsync(subjectTeacher);
            return NoContent();
        }

        [HttpDelete("{subjectId}/{teacherId}")]
        public async Task<IActionResult> Delete(int subjectId, int teacherId)
        {
            await _repository.DeleteAsync(subjectId, teacherId);
            return NoContent();
        }
    }
}