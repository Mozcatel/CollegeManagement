using CollegeManagement.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace CollegeManagement.Repository.EF
{
    internal class StudentsRepository : IStudentRepository
    {
        private readonly CollegeContext _context;

        public StudentsRepository(CollegeContext context)
        {
            this._context = context;
        }

        public void Delete(Student element)
        {
            _context.Students.Remove(element);
        }

        public async Task<IEnumerable<Student>> GetAsync()
        {
            return await _context.Students
                .Include(s => s.Grades)
                .ToListAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Grades)
                .Include(s => s.Grades.Select(g => g.Subject))
                .Include(s => s.Grades.Select(g => g.Subject.Teacher))
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public void Insert(Student element)
        {
            _context.Students.Add(element);
        }

        public void Update(Student element)
        {
            _context.Entry(element).State = EntityState.Modified;
        }
    }
}