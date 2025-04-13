using Microsoft.EntityFrameworkCore;
using SchoolDatabase.Data;
using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public class SubjectTeacherRepository : ISubjectTeacherRepository
    {
        private readonly SchoolContext _context;

        public SubjectTeacherRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubjectTeacher>> GetAllAsync()
        {
            return await _context.SubjectTeachers.ToListAsync();
        }

        public async Task<SubjectTeacher?> GetByIdsAsync(int subjectId, int teacherId)
        {
            return await _context.SubjectTeachers
                .FirstOrDefaultAsync(st => st.SubjectId == subjectId && st.TeacherId == teacherId);
        }

        public async Task AddAsync(SubjectTeacher subjectTeacher)
        {
            await _context.SubjectTeachers.AddAsync(subjectTeacher);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int subjectId, int teacherId)
        {
            var st = await GetByIdsAsync(subjectId, teacherId);
            if (st == null) return false;

            _context.SubjectTeachers.Remove(st);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(SubjectTeacher subjectTeacher)
        {
            var existing = await _context.SubjectTeachers
                .FirstOrDefaultAsync(st => st.SubjectId == subjectTeacher.SubjectId && st.TeacherId == subjectTeacher.TeacherId);

            if (existing == null) return false;

            // No additional fields, just update relationship if needed
            _context.SubjectTeachers.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
