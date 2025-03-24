using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.BloodGroups.Requests.Queries;
using Hms.Domain.BasicSetup;
using Hms.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.BloodGroups.Handlers.Queries
{
    public class GetSelectedBloodGroupRequestHandler : IRequestHandler<GetSelectedBloodGroupRequest, List<SelectedModel>>
    {
        public readonly IHmsRepository<BloodGroup> _bloodGroupRepository;
        public GetSelectedBloodGroupRequestHandler(IHmsRepository<BloodGroup> bloodGroupRepository)
        {
            _bloodGroupRepository = bloodGroupRepository;
        }
        public async Task<List<SelectedModel>> Handle(GetSelectedBloodGroupRequest request, CancellationToken cancellationToken)
        {
            var bloodGroups = await _bloodGroupRepository.Where(x => x.Status)
                                    .OrderBy(x => x.Status)
                                    .ToListAsync();

            List<SelectedModel> result = bloodGroups.Select(x => new SelectedModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}
