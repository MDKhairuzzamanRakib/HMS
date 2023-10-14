using Master_Details.Models;
using Master_Details.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Master_Details.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointDBEntities db = new AppointDBEntities();
        // GET: Appointment
        public ActionResult Index()
        {
            var appointments = db.Patients.Include(x=>x.Appointments.Select(y=>y.Department)).OrderByDescending(x=>x.PatientId).ToList();
            return View(appointments);
        }

        public ActionResult AddNewDepartment(int? id)
        {
            ViewBag.departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName", (id != null) ? id.ToString() : "");
            return PartialView("_addNewDepartment");

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AppointmentVM appointmentVM, int[] departmentId)
        {
            if (ModelState.IsValid)
            {
                Patient patient = new Patient()
                {
                    PatientName = appointmentVM.PatientName,
                    BirthDate = appointmentVM.BirthDate,
                    Age = appointmentVM.Age,
                    MaritalStatus = appointmentVM.MaritalStatus,
                    AppointmentDate = appointmentVM.AppointmentDate
                };

                HttpPostedFileBase file = appointmentVM.PictureFile;
                if (file != null)
                {
                    string filePath = Path.Combine("/Images/", Guid.NewGuid().ToString()+Path.GetExtension(file.FileName));

                    file.SaveAs(Server.MapPath(filePath));
                    patient.Picture = filePath;
                }

                foreach (var item in departmentId)
                {
                    Appointment appointment = new Appointment()
                    {
                        Patient = patient,
                        PatientId = patient.PatientId,
                        DepartmentId = item
                    };
                    db.Appointments.Add(appointment);
                }
                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");
        }

        public ActionResult Edit(int? id)
        {
            Patient patient = db.Patients.First(x => x.PatientId == id);
            var patientDep = db.Appointments.Where(x=>x.PatientId ==id).ToList();

            AppointmentVM appointmentVM = new AppointmentVM()
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                BirthDate = patient.BirthDate,
                Age = patient.Age,
                MaritalStatus = patient.MaritalStatus,
                AppointmentDate = patient.AppointmentDate,
                Picture = patient.Picture
            };
            Session["imgPath"] = patient.Picture;

            if (patientDep.Count() > 0)
            {
                foreach (var item in patientDep)
                {
                    appointmentVM.DepartmentList.Add(item.DepartmentId);
                }
            }
            return View(appointmentVM);
        }

        [HttpPost]
        public ActionResult Edit(AppointmentVM appointmentVM, int[] depId)
        {
            if (ModelState.IsValid)
            {

                Patient patient = new Patient()
                {
                    PatientId = appointmentVM.PatientId,
                    PatientName = appointmentVM.PatientName,
                    BirthDate = appointmentVM.BirthDate,
                    Age = appointmentVM.Age,
                    MaritalStatus = appointmentVM.MaritalStatus,
                    AppointmentDate = appointmentVM.AppointmentDate
                };

                HttpPostedFileBase file = appointmentVM.PictureFile;
                //string filePath = appointmentVM.Picture;
                if (file != null)
                {
                    string filePath = Path.Combine("/Images/", Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(filePath));
                    patient.Picture = filePath;
                }
                //else
                //{
                //    patient.Picture = Session["imgPath"].ToString();
                //}

                var depEntry = db.Appointments.Where(x => x.PatientId == patient.PatientId).ToList();
                foreach (var appointment in depEntry)
                {
                    db.Appointments.Remove(appointment);
                }

                foreach (var item in depId)
                {
                    Appointment appointment = new Appointment()
                    {
                        PatientId = patient.PatientId,
                        DepartmentId = item
                    };
                    db.Appointments.Add(appointment);
                }
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_success");
            }

            return PartialView("_error");
        }

        public ActionResult Delete(int? id)
        {
            Patient patient = db.Patients.First(x=>x.PatientId == id);
            var patientDep = db.Appointments.Where(x=>x.PatientId == id).ToList();

            AppointmentVM appointmentVM = new AppointmentVM()
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                Age = patient.Age,
                BirthDate = patient.BirthDate,
                Picture = patient.Picture,
                MaritalStatus = patient.MaritalStatus,
                AppointmentDate = patient.AppointmentDate
            };
            if (patientDep.Count()>0)
            {
                foreach (var item in patientDep)
                {
                    appointmentVM.DepartmentList.Add(item.DepartmentId);
                }
            }
            return View(appointmentVM);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DoDelete(int? id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            db.Entry(patient).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}