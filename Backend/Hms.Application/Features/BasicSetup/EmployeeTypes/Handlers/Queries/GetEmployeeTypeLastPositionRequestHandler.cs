using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Queries;
using Hms.Domain.BasicSetup;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.EmployeeTypes.Handlers.Queries
{
    public class GetEmployeeTypeLastPositionRequestHandler : IRequestHandler<GetEmployeeTypeLastPositionRequest, int>
    {
        private readonly IHmsRepository<EmployeeType> _EmployeeTypeRepository;
        public GetEmployeeTypeLastPositionRequestHandler(IHmsRepository<EmployeeType> EmployeeTypeRepository)
        {
            _EmployeeTypeRepository = EmployeeTypeRepository;
        }

        public async Task<int> Handle(GetEmployeeTypeLastPositionRequest request, CancellationToken cancellationToken)
        {
            var EmployeeType = await _EmployeeTypeRepository.Where(x => x.Status)
                                          .OrderByDescending(x => x.Position)
                                          .FirstOrDefaultAsync();

            var lastPosition = EmployeeType?.Position + 1 ?? 1;

            return lastPosition;
        }
    }
}
