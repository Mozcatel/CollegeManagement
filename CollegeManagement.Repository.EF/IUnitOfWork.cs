using System.Threading.Tasks;

namespace CollegeManagement.Repository.EF
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        IGradeRepository Grades { get; }
        ISubjectRepository Subjects { get; }
        ICourseRepository Courses { get; }
        ITeacherRepository Teachers { get; }

        Task<int> SaveChangesAsync();
    }
}