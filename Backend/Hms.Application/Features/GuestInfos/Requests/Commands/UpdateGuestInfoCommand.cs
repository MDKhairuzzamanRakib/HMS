using Hms.Application.DTOs.GuestInfos;
using Hms.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.GuestInfos.Requests.Commands
{
    public class UpdateGuestInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateGuestInfoDto GuestInfoDto { get; set; }
    }
}
