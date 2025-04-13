using Microsoft.EntityFrameworkCore;
using SchoolDatabase.Data;
using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly SchoolContext _context;

        public GroupRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups.Include(g => g.Students).ToListAsync();
        }

        public async Task<Group?> GetByIdAsync(int id)
        {
            return await _context.Groups.Include(g => g.Students).FirstOrDefaultAsync(g => g.GroupId == id);
        }

        public async Task<Group> CreateAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
