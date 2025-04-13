using SchoolDatabase.Models;

namespace SchoolApi.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group?> GetByIdAsync(int id);
        Task<Group> CreateAsync(Group group);
        Task UpdateAsync(Group group);
        Task DeleteAsync(int id);
    }
}
