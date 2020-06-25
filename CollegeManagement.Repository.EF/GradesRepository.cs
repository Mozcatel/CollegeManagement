using CollegeManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace CollegeManagement.Repository.EF
{
    internal class GradesRepository : IGradeRepository
    {
        private readonly CollegeContext _context;

        public GradesRepository(CollegeContext context)
        {
            this._context = context;
        }

        public void Delete(Grade element)
        {
            _context.Grades.Remove(element);
        }

        public async Task<IEnumerable<Grade>> GetAsync()
        {
            return await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .ToListAsync();
        }

        public async Task<Grade> GetAsync(int id)
        {
            return await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(g => g.GradeId == id);
        }

        public void Insert(Grade element)
        {
            _context.Grades.Add(element);
        }

        public void Update(Grade element)
        {
            _context.Entry(element).State = EntityState.Modified;
        }
    }
}