using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Genders.Requests.Queries;
using Hms.Domain.BasicSetup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Genders.Handlers.Queries
{
    public class GetGenderLastPositionRequestHandler : IRequestHandler<GetGenderLastPositionRequest, int>
    {
        private readonly IHmsRepository<Gender> _GenderRepository;
        public GetGenderLastPositionRequestHandler(IHmsRepository<Gender> GenderRepository)
        {
            _GenderRepository = GenderRepository;
        }

        public async Task<int> Handle(GetGenderLastPositionRequest request, CancellationToken cancellationToken)
        {
            var Gender = await _GenderRepository.Where(x => x.Status)
                                          .OrderByDescending(x => x.Position)
                                          .FirstOrDefaultAsync();

            var lastPosition = Gender?.Position + 1 ?? 1;

            return lastPosition;
        }
    }
}
