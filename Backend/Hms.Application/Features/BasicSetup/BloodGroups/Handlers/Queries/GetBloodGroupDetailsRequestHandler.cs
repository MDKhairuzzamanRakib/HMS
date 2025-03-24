using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.BasicSetup.BloodGroup;
using Hms.Application.Features.BasicSetup.BloodGroups.Requests.Queries;
using Hms.Domain.BasicSetup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.BloodGroups.Handlers.Queries
{
    public class GetBloodGroupDetailsRequestHandler : IRequestHandler<GetBloodGroupDetailsRequest, BloodGroupDto>
    {
        public readonly IHmsRepository<BloodGroup> _bloodGroupRepository;
        public readonly IMapper _mapper;
        public GetBloodGroupDetailsRequestHandler(IHmsRepository<BloodGroup> bloodGroupRepository, IMapper mapper)
        {
            _bloodGroupRepository = bloodGroupRepository;
            _mapper = mapper;
        }
        public async Task<BloodGroupDto> Handle(GetBloodGroupDetailsRequest request, CancellationToken cancellationToken)
        {
            var bloodGroups = await _bloodGroupRepository.FilterAsync(x => x.Id == request.Id);

            var bloodGroupDto = _mapper.Map<BloodGroupDto>(bloodGroups);

            return bloodGroupDto;
        }
    }
}
