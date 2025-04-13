using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Mark>> GetAllAsync();
        Task<Mark?> GetByIdAsync(int id);
        Task<Mark> CreateAsync(Mark mark);
        Task UpdateAsync(Mark mark);
        Task DeleteAsync(int id);
    }
}
