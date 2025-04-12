using Hms.Application.DTOs.BasicSetup.City;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Citys.Requests.Queries
{
    public class GetCityDetailsRequest : IRequest<CityDto>
    {
        public int Id { get; set; }
    }
}
