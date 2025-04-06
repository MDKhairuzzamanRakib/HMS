using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
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
    public class GetGenderDetailsRequestHandler : IRequestHandler<GetGenderDetailsRequest, CommonBasicSetupDto>
    {
        public readonly IHmsRepository<Gender> _GenderRepository;
        public readonly IMapper _mapper;
        public GetGenderDetailsRequestHandler(IHmsRepository<Gender> GenderRepository, IMapper mapper)
        {
            _GenderRepository = GenderRepository;
            _mapper = mapper;
        }
        public async Task<CommonBasicSetupDto> Handle(GetGenderDetailsRequest request, CancellationToken cancellationToken)
        {
            var Genders = await _GenderRepository.FilterAsync(x => x.Id == request.Id);

            var GenderDto = _mapper.Map<CommonBasicSetupDto>(Genders);

            return GenderDto;
        }
    }
}
