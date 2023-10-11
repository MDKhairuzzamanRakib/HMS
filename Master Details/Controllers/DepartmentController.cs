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
    }
}