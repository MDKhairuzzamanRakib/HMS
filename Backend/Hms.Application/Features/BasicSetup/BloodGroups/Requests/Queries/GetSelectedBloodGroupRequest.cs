using Hms.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.BloodGroups.Requests.Queries
{
    public class GetSelectedBloodGroupRequest : IRequest<List<SelectedModel>>
    {
    }
}
