using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public interface ISubjectTeacherRepository
    {
        Task<IEnumerable<SubjectTeacher>> GetAllAsync();
        Task<SubjectTeacher?> GetByIdsAsync(int subjectId, int teacherId);
        Task AddAsync(SubjectTeacher subjectTeacher);
        Task<bool> DeleteAsync(int subjectId, int teacherId);
        Task<bool> UpdateAsync(SubjectTeacher subjectTeacher);
    }
}
