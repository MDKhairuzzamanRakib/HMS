using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Commands
{
    public class CreateEmployeeTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateCommonBasicSetupDto EmployeeTypeDto { get; set; }
    }
}
