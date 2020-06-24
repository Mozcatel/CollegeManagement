using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagement.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();

        Task<T> GetAsync(int id);

        void Insert(T element);

        void Update(T element);

        void Delete(T element);
    }
}