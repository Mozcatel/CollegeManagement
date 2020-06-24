using CollegeManagement.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagement.MVC.Controllers
{
    public abstract class UnitOfWorkController : Controller
    {
        protected readonly UnitOfWork _unitOfWork = new UnitOfWork();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}