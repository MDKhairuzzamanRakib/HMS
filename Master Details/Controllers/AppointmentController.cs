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
                    string filePath = Path.Combine("/Images", Guid.NewGuid().ToString()+Path.GetExtension(file.FileName));

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


    }
}