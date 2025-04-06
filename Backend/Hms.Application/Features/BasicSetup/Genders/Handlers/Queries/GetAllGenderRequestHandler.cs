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
    public class GetAllGenderRequestHandler : IRequestHandler<GetAllGenderRequest, List<CommonBasicSetupDto>>
    {
        public readonly IHmsRepository<Gender> _GenderRepository;
        public readonly IMapper _mapper;
        public GetAllGenderRequestHandler(IHmsRepository<Gender> GenderRepository, IMapper mapper)
        {
            _GenderRepository = GenderRepository;
            _mapper = mapper;
        }

        public async Task<List<CommonBasicSetupDto>> Handle(GetAllGenderRequest request, CancellationToken cancellationToken)
        {
            var Genders = await _GenderRepository.Where(x => x.Status).OrderBy(x => x.Position).ToListAsync();

            var GenderDto = _mapper.Map<List<CommonBasicSetupDto>>(Genders);

            return GenderDto;
        }
    }
}
