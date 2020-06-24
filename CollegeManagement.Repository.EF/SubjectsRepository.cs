using CollegeManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Repository.EF
{
    internal class SubjectsRepository : ISubjectRepository
    {
        private readonly CollegeContext _context;

        public SubjectsRepository(CollegeContext context)
        {
            this._context = context;
        }

        public void Delete(Subject element)
        {
            _context.Subjects.Remove(element);
        }

        public async Task<IEnumerable<Subject>> GetAsync()
        {
            return await _context.Subjects
                .Include(s => s.Grades)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .ToListAsync();
        }

        public async Task<Subject> GetAsync(int id)
        {
            return await _context.Subjects
                .Include(s => s.Grades)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.Grades.Select(g => g.Student))
                .FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task<Subject> GetByNameAsync(string subjectName)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.SubjectName.Equals(subjectName));
        }

        public void Insert(Subject element)
        {
            _context.Subjects.Add(element);
        }

        public void Update(Subject element)
        {
            _context.Entry(element).State = EntityState.Modified;
        }
    }
}