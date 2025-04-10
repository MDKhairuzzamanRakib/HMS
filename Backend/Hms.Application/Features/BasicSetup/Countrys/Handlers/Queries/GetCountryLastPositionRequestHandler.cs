using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Countrys.Requests.Queries;
using Hms.Domain.BasicSetup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Countrys.Handlers.Queries
{
    public class GetCountryLastPositionRequestHandler : IRequestHandler<GetCountryLastPositionRequest, int>
    {
        private readonly IHmsRepository<Country> _CountryRepository;
        public GetCountryLastPositionRequestHandler(IHmsRepository<Country> CountryRepository)
        {
            _CountryRepository = CountryRepository;
        }

        public async Task<int> Handle(GetCountryLastPositionRequest request, CancellationToken cancellationToken)
        {
            var Country = await _CountryRepository.Where(x => x.Status)
                                          .OrderByDescending(x => x.Position)
                                          .FirstOrDefaultAsync();

            var lastPosition = Country?.Position + 1 ?? 1;

            return lastPosition;
        }
    }
}
