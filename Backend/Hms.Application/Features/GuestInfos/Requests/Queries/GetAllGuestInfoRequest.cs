using Hms.Application.DTOs.Common;
using Hms.Application.DTOs.GuestInfos;
using Hms.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.GuestInfos.Requests.Queries
{
    public class GetAllGuestInfoRequest : IRequest<PagedResult<GuestInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
