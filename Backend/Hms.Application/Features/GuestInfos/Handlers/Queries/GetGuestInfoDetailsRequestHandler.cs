using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.GuestInfos;
using Hms.Application.Features.GuestInfos.Requests.Queries;
using Hms.Application.Models;
using Hms.Domain.GuestInfos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.GuestInfos.Handlers.Queries
{
    public class GetGuestInfoDetailsRequestHandler : IRequestHandler<GetGuestInfoDetailsRequest, GuestInfoDto>
    {
        private readonly IHmsRepository<GuestInfo> _guestInfoRepository;
        private readonly IMapper _mapper;
        public GetGuestInfoDetailsRequestHandler(IHmsRepository<GuestInfo> guestInfoRepository, IMapper mapper)
        {
            _guestInfoRepository = guestInfoRepository;
            _mapper = mapper;
        }

        public async Task<GuestInfoDto> Handle(GetGuestInfoDetailsRequest request, CancellationToken cancellationToken)
        {
            var guestInfo = await _guestInfoRepository.Where(x => x.Id == request.GuestId)
                .Include(x => x.Gender)
                .Include(x => x.BloodGroup)
                .Include(x => x.Religion)
                .Include(x => x.MaritalStatus)
                .Include(x => x.Country)
                .Include(x => x.City)
                .FirstOrDefaultAsync(cancellationToken);

            if (guestInfo == null)
            {
                return null;
            }

            var guestInfoDtos = _mapper.Map<GuestInfoDto>(guestInfo);

            return guestInfoDtos;
        }
    }
}
