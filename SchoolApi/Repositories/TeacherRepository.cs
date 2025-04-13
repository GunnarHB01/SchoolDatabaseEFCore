using Microsoft.EntityFrameworkCore;
using SchoolDatabase.Data;
using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext _context;

        public TeacherRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher?> UpdateAsync(int id, Teacher updatedTeacher)
        {
            var existing = await _context.Teachers.FindAsync(id);
            if (existing == null) return null;

            existing.FirstName = updatedTeacher.FirstName;
            existing.LastName = updatedTeacher.LastName;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Teacher?> DeleteAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return null;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
