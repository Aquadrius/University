using Microsoft.EntityFrameworkCore;
using University.Domain.Configurations;
using University.Domain.Entity;

namespace University.DAL

{
    public class UniversityDbContext : DbContext
    {
        

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options)

        {

        }
        public DbSet<Stud> Stud { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Lecture> Lecture { get; set; }

        public DbSet<Labwork> Labwork { get; set; }        

        public DbSet<Review> Review { get; set; }

        public DbSet<Grade> Grade { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LabworkConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new StudConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            

            modelBuilder.Entity<Review>()
                        .HasMany(r => r.Labwork)
                        .WithOne(lab => lab.Review)
                        .HasPrincipalKey(r=>r.LabworkId);

            modelBuilder.Entity<Review>()
                       .HasMany(r => r.Stud)
                       .WithOne(s => s.Review)
                       .HasForeignKey(r => r.StudId);

            modelBuilder.Entity<Grade>()
                    .HasMany(g => g.Labwork)
                    .WithOne(lab => lab.Grade)
                    .HasPrincipalKey(g => g.LabworkId);

            modelBuilder.Entity<Grade>()
                       .HasMany(g => g.Stud)
                       .WithOne(s => s.Grade)
                       .HasForeignKey(g =>g.StudId);



            base.OnModelCreating(modelBuilder);
        }

      

    }
}
