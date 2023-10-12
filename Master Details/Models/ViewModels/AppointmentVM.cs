using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Master_Details.Models.ViewModels
{
    public class AppointmentVM
    {
        public AppointmentVM()
        {
            this.DepartmentList = new List<int>();
        }

        public int PatientId { get; set; }
        [Required, StringLength(50), Display(Name = "Patient Name")]
        public string PatientName { get; set;}
        public int Age { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Birth Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public bool MaritalStatus { get; set; }
        [Required, Column(TypeName = "date"), Display(Name = "Appointment Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase PictureFile { get; set; }
        public List<int> DepartmentList { get; set; }
    }
}