using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.BloodGroups.Requests.Commands
{
    public class CreateBloodGroupCommand : IRequest<BaseCommandResponse>
    {
        public CreateCommonBasicSetupDto BloodGroupDto { get; set; }
    }
}
