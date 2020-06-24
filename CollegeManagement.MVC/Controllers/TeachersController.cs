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
using CollegeManagement.MVC.Models;
using CollegeManagement.MVC.Utils;

namespace CollegeManagement.MVC.Controllers
{
    public class TeachersController : UnitOfWorkController
    {
        // GET: Teachers
        public async Task<ActionResult> Index()
        {
            var teachers = await _unitOfWork.Teachers.GetAsync();

            return View(teachers.MapToTeacherViewModel());
        }

        // GET: Teachers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await _unitOfWork.Teachers.GetAsync(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TeacherId,TeacherName,TeacherBirthDate,TeacherSalary")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Teachers.Insert(teacher);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await _unitOfWork.Teachers.GetAsync(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TeacherId,TeacherName,TeacherBirthDate,TeacherSalary")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Teachers.Update(teacher);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await _unitOfWork.Teachers.GetAsync(id.Value);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Teacher teacher = await _unitOfWork.Teachers.GetAsync(id);
            _unitOfWork.Teachers.Delete(teacher);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}