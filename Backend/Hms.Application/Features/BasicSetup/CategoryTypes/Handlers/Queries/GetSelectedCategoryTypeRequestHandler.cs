using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.CategoryTypes.Requests.Queries;
using Hms.Domain.BasicSetup;
using Hms.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.CategoryTypes.Handlers.Queries
{
    public class GetSelectedCategoryTypeRequestHandler : IRequestHandler<GetSelectedCategoryTypeRequest, List<SelectedModel>>
    {
        public readonly IHmsRepository<CategoryType> _CategoryTypeRepository;
        public GetSelectedCategoryTypeRequestHandler(IHmsRepository<CategoryType> CategoryTypeRepository)
        {
            _CategoryTypeRepository = CategoryTypeRepository;
        }
        public async Task<List<SelectedModel>> Handle(GetSelectedCategoryTypeRequest request, CancellationToken cancellationToken)
        {
            var CategoryTypes = await _CategoryTypeRepository.Where(x => x.Status)
                                    .OrderBy(x => x.Status)
                                    .ToListAsync();

            List<SelectedModel> result = CategoryTypes.Select(x => new SelectedModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}
