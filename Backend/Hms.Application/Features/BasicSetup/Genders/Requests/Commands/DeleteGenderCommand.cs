using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Genders.Requests.Commands
{
    public class DeleteGenderCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
