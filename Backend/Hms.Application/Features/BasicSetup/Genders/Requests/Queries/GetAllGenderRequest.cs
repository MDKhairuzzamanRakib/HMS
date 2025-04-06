using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Domain.BasicSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Genders.Requests.Queries
{
    public class GetAllGenderRequest : IRequest<List<CommonBasicSetupDto>>
    {
    }
}
