using Microsoft.AspNetCore.Mvc;
using SchoolApi.Repositories;
using SchoolDatabase.Models;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _repository;

        public SubjectsController(ISubjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetById(int id)
        {
            var subject = await _repository.GetByIdAsync(id);
            if (subject == null) return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> Create(Subject subject)
        {
            var created = await _repository.CreateAsync(subject);
            return CreatedAtAction(nameof(GetById), new { id = created.SubjectId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Subject subject)
        {
            if (id != subject.SubjectId) return BadRequest();
            await _repository.UpdateAsync(subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
