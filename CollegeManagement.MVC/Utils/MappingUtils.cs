using CollegeManagement.Model;
using CollegeManagement.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeManagement.MVC.Utils
{
    public static class MappingUtils
    {
        public static IEnumerable<CourseViewModel> MapToCourseViewModel(this IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                yield return new CourseViewModel
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    GradeAverage = (int)(course.Subjects.Average(s => s.Grades.Average(g => g.GradeValue))),
                    NumberOfStudents = course.Subjects.SelectMany(s => s.Grades.Select(g => g.Student)).Distinct().Count(),
                    NumberOfTeachers = course.Subjects.Select(s => s.TeacherId).Distinct().Count()
                };
            }
        }

        public static IEnumerable<StudentViewModel> MapToStudentViewModel(this IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                yield return new StudentViewModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    StudentRegNumber = student.StudentRegNumber,
                    StudentBirthDate = student.StudentBirthDate.ToString("dd/MM/yyyy")
                };
            }
        }

        public static IEnumerable<SubjectViewModel> MapToSubjectViewModel(this IEnumerable<Subject> subjects)
        {
            foreach (var subject in subjects)
            {
                yield return new SubjectViewModel
                {
                    SubjectId = subject.SubjectId,
                    SubjectName = subject.SubjectName,
                    CourseName = subject.Course.CourseName,
                    TeacherName = subject.Teacher.TeacherName,
                    NumberOfStudents = subject.Grades.Count()
                };
            }
        }

        public static IEnumerable<TeacherViewModel> MapToTeacherViewModel(this IEnumerable<Teacher> teachers)
        {
            foreach (var teacher in teachers)
            {
                yield return new TeacherViewModel
                {
                    TeacherId = teacher.TeacherId,
                    TeacherName = teacher.TeacherName,
                    TeacherBirthDate = teacher.TeacherBirthDate.ToString("dd/MM/yyyy"),
                    TeacherSalary = teacher.TeacherSalary
                };
            }
        }

        public static CourseDetailView MapToCourseDetailView(this Course course)
        {
            return new CourseDetailView
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Subjects = course.Subjects.Select(s =>
                new SubjectViewModel
                {
                    SubjectId = s.SubjectId,
                    SubjectName = s.SubjectName,
                    TeacherName = s.Teacher.TeacherName,
                    NumberOfStudents = s.Grades.Count()
                })
            };
        }

        public static StudentViewModel MapToStudentDetailView(this Student student)
        {
            return new StudentViewModel
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                StudentRegNumber = student.StudentRegNumber,
                StudentBirthDate = student.StudentBirthDate.ToString("dd/MM/yyyy"),
                Grades = student.Grades
            };
        }

        public static SubjectDetailView MapToSubjectDetailView(this Subject subject)
        {
            return new SubjectDetailView
            {
                CourseId = subject.CourseId,
                CourseName = subject.Course.CourseName,
                SubjectId = subject.SubjectId,
                SubjectName = subject.SubjectName,
                TeacherId = subject.TeacherId,
                TeacherName = subject.Teacher.TeacherName,
                Grades = subject.Grades.Select(g => new StudentGradeViewModel
                {
                    StudentId = g.StudentId,
                    StudentName = g.Student.StudentName,
                    StudentRegNumber = g.Student.StudentRegNumber,
                    StudentBirthDate = g.Student.StudentBirthDate.ToString("dd/MM/yyyy"),
                    GradeValue = g.GradeValue
                })
            };
        }
    }
}