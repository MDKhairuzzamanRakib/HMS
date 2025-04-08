using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.GuestInfos;
using Hms.Application.Features.GuestInfos.Requests.Queries;
using Hms.Application.Models;
using Hms.Domain.GuestInfos;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.GuestInfos.Handlers.Queries
{
    public class GetAllGuestInfoRequestHandler : IRequestHandler<GetAllGuestInfoRequest, PagedResult<GuestInfoDto>>
    {
        private readonly IHmsRepository<GuestInfo> _guestInfoRepository;
        private readonly IMapper _mapper;
        public GetAllGuestInfoRequestHandler(IHmsRepository<GuestInfo> guestInfoRepository, IMapper mapper)
        {
            _guestInfoRepository = guestInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GuestInfoDto>> Handle(GetAllGuestInfoRequest request, CancellationToken cancellationToken)
        {
            IQueryable<GuestInfo> guestInfos = _guestInfoRepository.FilterWithInclude(x =>
                x.FirstName.ToLower().Contains(request.QueryParams.SearchText) ||
                x.MiddleName.ToLower().Contains(request.QueryParams.SearchText) ||
                x.LastName.ToLower().Contains(request.QueryParams.SearchText) ||
                x.Email.ToLower().Contains(request.QueryParams.SearchText) ||
                String.IsNullOrEmpty(request.QueryParams.SearchText))
                    .Include(x => x.Gender)
                    .Include(x => x.BloodGroup)
                    .Include(x => x.Religion)
                    .Include(x => x.MaritalStatus)
                    .Include(x => x.Country)
                    .Include(x => x.City);

            var totalCount = guestInfos.Count();

            guestInfos = guestInfos.OrderByDescending(x => x.DateCreated)
                .Skip((request.QueryParams.PageIndex - 1) * request.QueryParams.PageSize)
                .Take(request.QueryParams.PageSize);

            var guestInfoDtos = _mapper.Map<List<GuestInfoDto>>(guestInfos);

            var result = new PagedResult<GuestInfoDto>(guestInfoDtos, totalCount, request.QueryParams.PageIndex, request.QueryParams.PageSize);

            return result;
        }
    }
}
