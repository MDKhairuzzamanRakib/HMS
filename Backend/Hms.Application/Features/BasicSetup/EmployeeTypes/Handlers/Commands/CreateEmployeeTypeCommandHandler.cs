using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Commands;
using Hms.Application.Features.Common;
using Hms.Application.Responses;
using Hms.Domain.BasicSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.EmployeeTypes.Handlers.Commands
{
    public class CreateEmployeeTypeCommandHandler : IRequestHandler<CreateEmployeeTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public CreateEmployeeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(CreateEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.EmployeeTypeDto.Name;

            if (_existenceChecker.EntityExists<EmployeeType>("Name", name, "Id", request.EmployeeTypeDto.Id))
            {
                response.Success = false;
                response.Message = $"Creation Failed '{name}' already exists.";
            }
            else
            {
                var EmployeeType = _mapper.Map<EmployeeType>(request.EmployeeTypeDto);

                EmployeeType = await _unitOfWork.Repository<EmployeeType>().Add(EmployeeType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = EmployeeType.Id;
            }
            return response;
        }
    }
}