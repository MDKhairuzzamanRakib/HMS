using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Queries;
using Hms.Domain.BasicSetup;
using Hms.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.EmployeeTypes.Handlers.Queries
{
    public class GetSelectedEmployeeTypeRequestHandler : IRequestHandler<GetSelectedEmployeeTypeRequest, List<SelectedModel>>
    {
        public readonly IHmsRepository<EmployeeType> _EmployeeTypeRepository;
        public GetSelectedEmployeeTypeRequestHandler(IHmsRepository<EmployeeType> EmployeeTypeRepository)
        {
            _EmployeeTypeRepository = EmployeeTypeRepository;
        }
        public async Task<List<SelectedModel>> Handle(GetSelectedEmployeeTypeRequest request, CancellationToken cancellationToken)
        {
            var EmployeeTypes = await _EmployeeTypeRepository.Where(x => x.Status)
                                    .OrderBy(x => x.Status)
                                    .ToListAsync();

            List<SelectedModel> result = EmployeeTypes.Select(x => new SelectedModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}
