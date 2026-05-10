using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Queries
{
    public class GetEmployeeTypeDetailsRequest : IRequest<CommonBasicSetupDto>
    {
        public int Id { get; set; }
    }
}
