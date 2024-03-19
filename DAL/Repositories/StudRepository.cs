using Microsoft.EntityFrameworkCore;
using University.DAL.Repositories.Interfaces;
using University.Domain.Entity;

namespace University.DAL.Repositories
{
    public class StudRepository : IStudRepository
    {
        private readonly UniversityDbContext _db;

        public StudRepository(UniversityDbContext db)
        {

            _db = db;

        }
        public async Task<bool> Create(Stud entity)//создание нового студента
        {
            await _db.Stud.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Stud entity)//удаление студента
        {
            _db.Stud.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Stud> Get(int id)// получение студента по ID
        {
            return await _db.Stud.FirstOrDefaultAsync(x => x.StudId == id);
        }

        public async Task<Stud> GetByName(string name)//получение студента по имени
        {
            return await _db.Stud.FirstOrDefaultAsync(x => x.Firstname.Contains(name));
        }

        public async Task<List<Stud>> Select()//получение списка всех студентов
        {
            return await _db.Stud.ToListAsync();
        }

        public async Task<List<Stud>> SelectAll(int studId)//получение всех лекций студента
        {
            return await _db.Stud.Where(s=>s.StudId==studId).Include(s => s.Lecture).ToListAsync();                     

        }

      //  public async Task<List<Stud>> SelectLabworksWithReview(int studId, int labId)
      //  {
       //    return await _db.Stud.Where(s => s.StudId == studId).Include(s => s.Labwork)
                               //  .Include(lab => lab.Review).ToListAsync();
       //}
    }
}
