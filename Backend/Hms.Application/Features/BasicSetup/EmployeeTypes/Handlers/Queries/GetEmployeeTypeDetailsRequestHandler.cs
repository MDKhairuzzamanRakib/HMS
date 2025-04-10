using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
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
    public class GetEmployeeTypeDetailsRequestHandler : IRequestHandler<GetEmployeeTypeDetailsRequest, CommonBasicSetupDto>
    {
        public readonly IHmsRepository<EmployeeType> _EmployeeTypeRepository;
        public readonly IMapper _mapper;
        public GetEmployeeTypeDetailsRequestHandler(IHmsRepository<EmployeeType> EmployeeTypeRepository, IMapper mapper)
        {
            _EmployeeTypeRepository = EmployeeTypeRepository;
            _mapper = mapper;
        }
        public async Task<CommonBasicSetupDto> Handle(GetEmployeeTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var EmployeeTypes = await _EmployeeTypeRepository.FilterAsync(x => x.Id == request.Id);

            var EmployeeTypeDto = _mapper.Map<CommonBasicSetupDto>(EmployeeTypes);

            return EmployeeTypeDto;
        }
    }
}
