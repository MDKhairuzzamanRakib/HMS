using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Citys.Requests.Queries;
using Hms.Domain.BasicSetup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Citys.Handlers.Queries
{
    public class GetCityLastPositionRequestHandler : IRequestHandler<GetCityLastPositionRequest, int>
    {
        private readonly IHmsRepository<City> _CityRepository;
        public GetCityLastPositionRequestHandler(IHmsRepository<City> CityRepository)
        {
            _CityRepository = CityRepository;
        }

        public async Task<int> Handle(GetCityLastPositionRequest request, CancellationToken cancellationToken)
        {
            var City = await _CityRepository.Where(x => x.Status)
                                          .OrderByDescending(x => x.Position)
                                          .FirstOrDefaultAsync();

            var lastPosition = City?.Position + 1 ?? 1;

            return lastPosition;
        }
    }
}
