using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task<Teacher?> UpdateAsync(int id, Teacher updatedTeacher);
        Task<Teacher?> DeleteAsync(int id);
    }
}
