using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Models
{
    public class CourseDetailView
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }

        public IEnumerable<SubjectViewModel> Subjects { get; set; }
    }
}