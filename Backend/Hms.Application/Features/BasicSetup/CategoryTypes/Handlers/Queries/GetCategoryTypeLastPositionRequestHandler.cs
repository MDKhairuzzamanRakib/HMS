using Hms.Application.Contracts.Persistence;
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
    public class GetCategoryTypeLastPositionRequestHandler : IRequestHandler<GetCategoryTypeLastPositionRequest, int>
    {
        private readonly IHmsRepository<CategoryType> _CategoryTypeRepository;
        public GetCategoryTypeLastPositionRequestHandler(IHmsRepository<CategoryType> CategoryTypeRepository)
        {
            _CategoryTypeRepository = CategoryTypeRepository;
        }

        public async Task<int> Handle(GetCategoryTypeLastPositionRequest request, CancellationToken cancellationToken)
        {
            var CategoryType = await _CategoryTypeRepository.Where(x => x.Status)
                                          .OrderByDescending(x => x.Position)
                                          .FirstOrDefaultAsync();

            var lastPosition = CategoryType?.Position + 1 ?? 1;

            return lastPosition;
        }
    }
}
