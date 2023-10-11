using Master_Details.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Master_Details.Controllers
{
    public class DepartmentController : Controller
    {
        AppointDBEntities db = new AppointDBEntities();
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");
        }


        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}