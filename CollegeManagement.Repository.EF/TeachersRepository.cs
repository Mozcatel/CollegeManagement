using CollegeManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CollegeManagement.Repository.EF
{
    internal class TeachersRepository : ITeacherRepository
    {
        private readonly CollegeContext _context;

        public TeachersRepository(CollegeContext context)
        {
            this._context = context;
        }

        public void Delete(Teacher element)
        {
            _context.Teachers.Remove(element);
        }

        public async Task<IEnumerable<Teacher>> GetAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public void Insert(Teacher element)
        {
            _context.Teachers.Add(element);
        }

        public void Update(Teacher element)
        {
            _context.Entry(element).State = EntityState.Modified;
        }
    }
}