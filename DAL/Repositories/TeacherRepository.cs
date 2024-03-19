using Microsoft.EntityFrameworkCore;
using University.DAL.Repositories.Interfaces;
using University.Domain.Entity;

namespace University.DAL.Repositories
{
    public class TeacherRepository:ITeachersRepository 
    {

        private readonly UniversityDbContext _db;

        public TeacherRepository(UniversityDbContext db)
        {

            _db = db;

        }
        public async Task<List<Teacher>> GetTeachers()// получение списка преподавателей
        {
            return await _db.Teacher.AsNoTracking().ToListAsync();
                            
        }

        public async Task Add(Teacher entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();            
        }
        public async Task<List<Teacher>> Select(int teachId)//получение всех лекций преподавателя
        {
            return await _db.Teacher.Where(s => s.TeacherId == teachId).Include(s => s.Lecture).ToListAsync();

        }
    }
}
