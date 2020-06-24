using CollegeManagement.Model;
using System.Data.Entity;

namespace CollegeManagement.Repository.EF
{
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("CollegeContext")
        {
            Database.SetInitializer(new CollegeInitializer());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithRequired(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Subjects)
                .WithRequired(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentRegNumber)
                .IsUnique();

            modelBuilder.Entity<Student>()
            .HasMany(s => s.Grades)
            .WithRequired(g => g.Student)
            .HasForeignKey(g => g.StudentId)
            .WillCascadeOnDelete();

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Grades)
                .WithRequired(g => g.Subject)
                .HasForeignKey(g => g.SubjectId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Grade>()
                .HasKey(g => new { g.GradeId, g.StudentId, g.SubjectId })
                .HasIndex(g => new { g.SubjectId, g.StudentId })
                .IsUnique();

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Student)
                .WithMany(s => s.Grades);

            modelBuilder.Entity<Grade>()
                .HasRequired(g => g.Subject)
                .WithMany(s => s.Grades);
        }
    }
}