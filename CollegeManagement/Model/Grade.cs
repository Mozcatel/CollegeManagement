﻿namespace CollegeManagement.Model
{
    public class Grade
    {
        public int GradeId { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int GradeValue { get; set; }
    }
}