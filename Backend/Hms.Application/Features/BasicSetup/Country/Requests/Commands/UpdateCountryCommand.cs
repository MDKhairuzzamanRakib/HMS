using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Countrys.Requests.Commands
{
    public class UpdateCountryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCommonBasicSetupDto CountryDto { get; set; }
    }
}