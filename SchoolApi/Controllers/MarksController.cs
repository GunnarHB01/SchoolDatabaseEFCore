using Microsoft.AspNetCore.Mvc;
using SchoolApi.Repositories;
using SchoolDatabase.Models;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarksController : ControllerBase
    {
        private readonly IMarkRepository _repository;

        public MarksController(IMarkRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mark>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetById(int id)
        {
            var mark = await _repository.GetByIdAsync(id);
            if (mark == null) return NotFound();
            return Ok(mark);
        }

        [HttpPost]
        public async Task<ActionResult<Mark>> Create(Mark mark)
        {
            var created = await _repository.CreateAsync(mark);
            return CreatedAtAction(nameof(GetById), new { id = created.MarkId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Mark mark)
        {
            if (id != mark.MarkId) return BadRequest();
            await _repository.UpdateAsync(mark);
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
