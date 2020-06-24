using CollegeManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Repository.EF
{
    internal class CoursesRepository : ICourseRepository
    {
        private readonly CollegeContext _context;

        public CoursesRepository(CollegeContext context)
        {
            this._context = context;
        }

        public void Delete(Course element)
        {
            _context.Courses.Remove(element);
        }

        public async Task<IEnumerable<Course>> GetAsync()
        {
            return await _context.Courses
                .Include(c => c.Subjects)
                .Include(c => c.Subjects.Select(s => s.Grades))
                .Include(c => c.Subjects.Select(s => s.Grades.Select(g => g.Student)))
                .ToListAsync();
        }

        public async Task<Course> GetAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Subjects)
                .Include(c => c.Subjects.Select(s => s.Grades))
                .Include(c => c.Subjects.Select(s => s.Grades.Select(g => g.Student)))
                .Include(c => c.Subjects.Select(s => s.Teacher))
                .FirstOrDefaultAsync(c => c.CourseId == id);
        }

        public void Insert(Course element)
        {
            _context.Courses.Add(element);
        }

        public void Update(Course element)
        {
            _context.Entry(element).State = EntityState.Modified;
        }
    }
}