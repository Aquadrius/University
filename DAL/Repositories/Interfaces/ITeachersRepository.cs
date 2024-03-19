using University.Domain.Entity;

namespace University.DAL.Repositories.Interfaces
{
    public interface ITeachersRepository
    {
        Task<List<Teacher>> GetTeachers();

        Task Add(Teacher entity);

        Task<List<Teacher>> Select(int teachId);
    }
}
