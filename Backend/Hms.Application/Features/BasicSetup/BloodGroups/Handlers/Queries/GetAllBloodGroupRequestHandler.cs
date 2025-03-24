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
    public class GetAllBloodGroupRequestHandler : IRequestHandler<GetAllBloodGroupRequest, List<BloodGroupDto>>
    {
        public readonly IHmsRepository<BloodGroup> _bloodGroupRepository;
        public readonly IMapper _mapper;
        public GetAllBloodGroupRequestHandler(IHmsRepository<BloodGroup> bloodGroupRepository, IMapper mapper)
        {
            _bloodGroupRepository = bloodGroupRepository;
            _mapper = mapper;
        }

        public async Task<List<BloodGroupDto>> Handle(GetAllBloodGroupRequest request, CancellationToken cancellationToken)
        {
            var bloodGroups = await _bloodGroupRepository.Where(x => x.Status).OrderBy(x => x.Position).ToListAsync();

            var bloodGroupDto = _mapper.Map<List<BloodGroupDto>>(bloodGroups);

            return bloodGroupDto;
        }
    }
}
