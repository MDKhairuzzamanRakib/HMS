using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
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
    public class GetCountryDetailsRequestHandler : IRequestHandler<GetCountryDetailsRequest, CommonBasicSetupDto>
    {
        public readonly IHmsRepository<Country> _CountryRepository;
        public readonly IMapper _mapper;
        public GetCountryDetailsRequestHandler(IHmsRepository<Country> CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
            _mapper = mapper;
        }
        public async Task<CommonBasicSetupDto> Handle(GetCountryDetailsRequest request, CancellationToken cancellationToken)
        {
            var Countrys = await _CountryRepository.FilterAsync(x => x.Id == request.Id);

            var CountryDto = _mapper.Map<CommonBasicSetupDto>(Countrys);

            return CountryDto;
        }
    }
}
