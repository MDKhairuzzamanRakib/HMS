using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.BloodGroups.Requests.Commands
{
    public class DeleteBloodGroupCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
