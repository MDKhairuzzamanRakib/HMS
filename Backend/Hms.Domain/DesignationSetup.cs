using Hms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Domain
{
    public class DesignationSetup : BaseDomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public string? Remark { get; set; }
        public int? Position { get; set; }
        public bool Status { get; set; }
    }
}
