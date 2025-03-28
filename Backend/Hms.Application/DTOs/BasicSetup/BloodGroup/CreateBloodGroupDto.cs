using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.DTOs.BasicSetup.BloodGroup
{
    public class CreateBloodGroupDto : IBloodGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Remark { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }
    }
}
