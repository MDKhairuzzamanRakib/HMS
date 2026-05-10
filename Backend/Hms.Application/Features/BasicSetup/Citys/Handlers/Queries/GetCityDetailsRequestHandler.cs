using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.BasicSetup.City;
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
    public class GetCityDetailsRequestHandler : IRequestHandler<GetCityDetailsRequest, CityDto>
    {
        public readonly IHmsRepository<City> _CityRepository;
        public readonly IMapper _mapper;
        public GetCityDetailsRequestHandler(IHmsRepository<City> CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }
        public async Task<CityDto> Handle(GetCityDetailsRequest request, CancellationToken cancellationToken)
        {
            var Citys = await _CityRepository.FilterAsync(x => x.Id == request.Id);

            var CityDto = _mapper.Map<CityDto>(Citys);

            return CityDto;
        }
    }
}
