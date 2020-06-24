using CollegeManagement.Model;
using System.Threading.Tasks;

namespace CollegeManagement.Repository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<Subject> GetByNameAsync(string subjectName);
    }
}