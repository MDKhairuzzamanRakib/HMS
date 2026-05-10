using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Countrys.Requests.Queries;
using Hms.Domain.BasicSetup;
using Hms.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Countrys.Handlers.Queries
{
    public class GetSelectedCountryRequestHandler : IRequestHandler<GetSelectedCountryRequest, List<SelectedModel>>
    {
        public readonly IHmsRepository<Country> _CountryRepository;
        public GetSelectedCountryRequestHandler(IHmsRepository<Country> CountryRepository)
        {
            _CountryRepository = CountryRepository;
        }
        public async Task<List<SelectedModel>> Handle(GetSelectedCountryRequest request, CancellationToken cancellationToken)
        {
            var Countrys = await _CountryRepository.Where(x => x.Status)
                                    .OrderBy(x => x.Status)
                                    .ToListAsync();

            List<SelectedModel> result = Countrys.Select(x => new SelectedModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}
