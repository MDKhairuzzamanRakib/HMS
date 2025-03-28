using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.Features.BasicSetup.CategoryTypes.Requests.Queries;
using Hms.Domain.BasicSetup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.CategoryTypes.Handlers.Queries
{
    public class GetCategoryTypeDetailsRequestHandler : IRequestHandler<GetCategoryTypeDetailsRequest, CommonBasicSetupDto>
    {
        public readonly IHmsRepository<CategoryType> _CategoryTypeRepository;
        public readonly IMapper _mapper;
        public GetCategoryTypeDetailsRequestHandler(IHmsRepository<CategoryType> CategoryTypeRepository, IMapper mapper)
        {
            _CategoryTypeRepository = CategoryTypeRepository;
            _mapper = mapper;
        }
        public async Task<CommonBasicSetupDto> Handle(GetCategoryTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var CategoryTypes = await _CategoryTypeRepository.FilterAsync(x => x.Id == request.Id);

            var CategoryTypeDto = _mapper.Map<CommonBasicSetupDto>(CategoryTypes);

            return CategoryTypeDto;
        }
    }
}
