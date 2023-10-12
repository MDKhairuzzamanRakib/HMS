using Master_Details.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}