using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Genders.Requests.Queries;
using Hms.Domain.BasicSetup;
using Hms.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Genders.Handlers.Queries
{
    public class GetSelectedGenderRequestHandler : IRequestHandler<GetSelectedGenderRequest, List<SelectedModel>>
    {
        public readonly IHmsRepository<Gender> _GenderRepository;
        public GetSelectedGenderRequestHandler(IHmsRepository<Gender> GenderRepository)
        {
            _GenderRepository = GenderRepository;
        }
        public async Task<List<SelectedModel>> Handle(GetSelectedGenderRequest request, CancellationToken cancellationToken)
        {
            var Genders = await _GenderRepository.Where(x => x.Status)
                                    .OrderBy(x => x.Status)
                                    .ToListAsync();

            List<SelectedModel> result = Genders.Select(x => new SelectedModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}
