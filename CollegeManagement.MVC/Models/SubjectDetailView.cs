using CollegeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Models
{
    public class SubjectDetailView
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public IEnumerable<StudentGradeViewModel> Grades { get; set; }
    }
}