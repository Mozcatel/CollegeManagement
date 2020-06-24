using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeManagement.Model;
using CollegeManagement.Repository.EF;

namespace CollegeManagement.MVC.Controllers
{
    public class GradesController : UnitOfWorkController
    {
        // GET: Grades
        public async Task<ActionResult> Index()
        {
            return View(await _unitOfWork.Grades.GetAsync());
        }

        // GET: Grades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = await _unitOfWork.Grades.GetAsync(id.Value);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // GET: Grades/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.StudentId = new SelectList(await _unitOfWork.Students.GetAsync(), "StudentId", "StudentName");
            ViewBag.SubjectId = new SelectList(await _unitOfWork.Subjects.GetAsync(), "SubjectId", "SubjectName");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GradeId,SubjectId,StudentId,GradeValue")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Grades.Insert(grade);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(await _unitOfWork.Students.GetAsync(), "StudentId", "StudentName", grade.StudentId);
            ViewBag.SubjectId = new SelectList(await _unitOfWork.Subjects.GetAsync(), "SubjectId", "SubjectName", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = await _unitOfWork.Grades.GetAsync(id.Value);
            if (grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(await _unitOfWork.Students.GetAsync(), "StudentId", "StudentName", grade.StudentId);
            ViewBag.SubjectId = new SelectList(await _unitOfWork.Subjects.GetAsync(), "SubjectId", "SubjectName", grade.SubjectId);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GradeId,SubjectId,StudentId,GradeValue")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Grades.Update(grade);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(await _unitOfWork.Students.GetAsync(), "StudentId", "StudentName", grade.StudentId);
            ViewBag.SubjectId = new SelectList(await _unitOfWork.Subjects.GetAsync(), "SubjectId", "SubjectName", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = await _unitOfWork.Grades.GetAsync(id.Value);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Grade grade = await _unitOfWork.Grades.GetAsync(id);
            _unitOfWork.Grades.Delete(grade);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}