using Microsoft.EntityFrameworkCore;
using University.Domain.Entity;

namespace University.DAL.Repositories
{
    public class AnalyticModuleRepo
    {
        private readonly UniversityDbContext _db;

        public AnalyticModuleRepo(UniversityDbContext db)
        {

            _db = db;

        }


         public async Task<List<Stud>> SelectFailingStudent()
        {
           return await _db.Stud.FromSqlRaw("GetFailingStudent").ToListAsync() ;
        }
    }
}
