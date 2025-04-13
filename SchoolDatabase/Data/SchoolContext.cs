using Microsoft.EntityFrameworkCore;
using SchoolDatabase.Models;

namespace SchoolDatabase.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectTeacher>().HasKey(st => new { st.SubjectId, st.TeacherId });

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Subject)
                .WithMany(s => s.SubjectTeachers)
                .HasForeignKey(st => st.SubjectId);

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(t => t.SubjectTeachers)
                .HasForeignKey(st => st.TeacherId);
        }
    }
}