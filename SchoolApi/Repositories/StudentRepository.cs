using Microsoft.EntityFrameworkCore;
using SchoolApi.Repositories;
using SchoolDatabase.Data;
using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() =>
            await _context.Students.Include(s => s.Group).ToListAsync();

        public async Task<Student?> GetByIdAsync(int id) =>
            await _context.Students.Include(s => s.Group).FirstOrDefaultAsync(s => s.StudentId == id);

        public async Task CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            if (!_context.Students.Any(s => s.StudentId == student.StudentId))
                return false;

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}