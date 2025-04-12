using Hms.Application.DTOs.BasicSetup.City;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Citys.Requests.Commands
{
    public class CreateCityCommand : IRequest<BaseCommandResponse>
    {
        public CreateCityDto CityDto { get; set; }
    }
}
