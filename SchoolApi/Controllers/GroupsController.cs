using Microsoft.AspNetCore.Mvc;
using SchoolApi.Repositories;
using SchoolDatabase.Models;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _repository;

        public GroupsController(IGroupRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetById(int id)
        {
            var group = await _repository.GetByIdAsync(id);
            if (group == null) return NotFound();
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<Group>> Create(Group group)
        {
            var created = await _repository.CreateAsync(group);
            return CreatedAtAction(nameof(GetById), new { id = created.GroupId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Group group)
        {
            if (id != group.GroupId) return BadRequest();
            await _repository.UpdateAsync(group);
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
