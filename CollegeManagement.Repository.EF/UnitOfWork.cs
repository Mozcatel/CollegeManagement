using System;
using System.Threading.Tasks;

namespace CollegeManagement.Repository.EF
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CollegeContext _context;

        private IStudentRepository _students;
        private IGradeRepository _grades;
        private ISubjectRepository _subjects;
        private ICourseRepository _courses;
        private ITeacherRepository _teachers;

        public UnitOfWork()
        {
            this._context = new CollegeContext();
        }

        public IStudentRepository Students
        {
            get
            {
                if (_students == null)
                    _students = new StudentsRepository(_context);
                return _students;
            }
        }

        public IGradeRepository Grades
        {
            get
            {
                if (_grades == null)
                    _grades = new GradesRepository(_context);
                return _grades;
            }
        }

        public ISubjectRepository Subjects
        {
            get
            {
                if (_subjects == null)
                    _subjects = new SubjectsRepository(_context);
                return _subjects;
            }
        }

        public ICourseRepository Courses
        {
            get
            {
                if (_courses == null)
                    _courses = new CoursesRepository(_context);
                return _courses;
            }
        }

        public ITeacherRepository Teachers
        {
            get
            {
                if (_teachers == null)
                    _teachers = new TeachersRepository(_context);
                return _teachers;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}