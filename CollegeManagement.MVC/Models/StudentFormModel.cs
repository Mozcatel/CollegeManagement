using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Models
{
    public class StudentFormModel
    {
        public int StudentId { get; set; }
        public int StudentRegNumber { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string SubjectName { get; set; }

        public int GradeValue { get; set; }
    }
}