using Hms.Application.DTOs.GuestInfos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.GuestInfos.Requests.Queries
{
    public class GetGuestInfoDetailsRequest : IRequest<GuestInfoDto>
    {
        public int GuestId { get; set; }
    }
}
