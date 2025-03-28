using Hms.Application.Contracts.Persistence;
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
    public class GetBloodGroupLastPositionRequestHandler : IRequestHandler<GetBloodGroupLastPositionRequest, int>
    {
        private readonly IHmsRepository<BloodGroup> _bloodGroupRepository;
        public GetBloodGroupLastPositionRequestHandler(IHmsRepository<BloodGroup> bloodGroupRepository)
        {
            _bloodGroupRepository = bloodGroupRepository;
        }

        public async Task<int> Handle(GetBloodGroupLastPositionRequest request, CancellationToken cancellationToken)
        {
            var bloodGroup = await _bloodGroupRepository.Where(x => x.Status)
                                          .OrderByDescending(x => x.Position)
                                          .FirstOrDefaultAsync();

            var lastPosition = bloodGroup?.Position + 1 ?? 1;

            return lastPosition;
        }
    }
}
