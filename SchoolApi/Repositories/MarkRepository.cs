using Microsoft.EntityFrameworkCore;
using SchoolDatabase.Data;
using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly SchoolContext _context;

        public MarkRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mark>> GetAllAsync()
        {
            return await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .ToListAsync();
        }

        public async Task<Mark?> GetByIdAsync(int id)
        {
            return await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.MarkId == id);
        }

        public async Task<Mark> CreateAsync(Mark mark)
        {
            _context.Marks.Add(mark);
            await _context.SaveChangesAsync();
            return mark;
        }

        public async Task UpdateAsync(Mark mark)
        {
            _context.Entry(mark).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mark = await _context.Marks.FindAsync(id);
            if (mark != null)
            {
                _context.Marks.Remove(mark);
                await _context.SaveChangesAsync();
            }
        }
    }
}
