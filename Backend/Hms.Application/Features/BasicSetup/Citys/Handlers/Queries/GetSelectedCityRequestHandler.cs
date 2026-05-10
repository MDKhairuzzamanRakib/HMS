using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Citys.Requests.Queries;
using Hms.Domain.BasicSetup;
using Hms.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Citys.Handlers.Queries
{
    public class GetSelectedCityRequestHandler : IRequestHandler<GetSelectedCityRequest, List<SelectedModel>>
    {
        public readonly IHmsRepository<City> _CityRepository;
        public GetSelectedCityRequestHandler(IHmsRepository<City> CityRepository)
        {
            _CityRepository = CityRepository;
        }
        public async Task<List<SelectedModel>> Handle(GetSelectedCityRequest request, CancellationToken cancellationToken)
        {
            var Citys = await _CityRepository.Where(x => x.Status)
                                    .OrderBy(x => x.Status)
                                    .ToListAsync();

            List<SelectedModel> result = Citys.Select(x => new SelectedModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}
