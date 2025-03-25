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
    public class GetAllCategoryTypeRequestHandler : IRequestHandler<GetAllCategoryTypeRequest, List<CommonBasicSetupDto>>
    {
        public readonly IHmsRepository<CategoryType> _CategoryTypeRepository;
        public readonly IMapper _mapper;
        public GetAllCategoryTypeRequestHandler(IHmsRepository<CategoryType> CategoryTypeRepository, IMapper mapper)
        {
            _CategoryTypeRepository = CategoryTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<CommonBasicSetupDto>> Handle(GetAllCategoryTypeRequest request, CancellationToken cancellationToken)
        {
            var CategoryTypes = await _CategoryTypeRepository.Where(x => x.Status).OrderBy(x => x.Position).ToListAsync();

            var CategoryTypeDto = _mapper.Map<List<CommonBasicSetupDto>>(CategoryTypes);

            return CategoryTypeDto;
        }
    }
}
