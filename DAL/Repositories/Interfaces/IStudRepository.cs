using University.Domain.Entity;

namespace University.DAL.Repositories.Interfaces
{
    public interface IStudRepository : IBaseRepository<Stud>
    {
        Task<Stud> GetByName(string name);

        Task<List<Stud>> SelectAll(int studId);

        //Task<List<Stud>> SelectLabworksWithReview(int studId,int labId);

    }


}
