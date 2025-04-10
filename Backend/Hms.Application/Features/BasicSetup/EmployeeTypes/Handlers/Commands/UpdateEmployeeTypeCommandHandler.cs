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
    public class UpdateEmployeeTypeCommandHandler : IRequestHandler<UpdateEmployeeTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public UpdateEmployeeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(UpdateEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.EmployeeTypeDto.Name;

            if (_existenceChecker.EntityExists<EmployeeType>("Name", name, "Id", request.EmployeeTypeDto.Id))
            {
                response.Success = false;
                response.Message = $"Update Failed '{name}' already exists.";
            }
            else
            {
                var EmployeeType = await _unitOfWork.Repository<EmployeeType>().Get(request.EmployeeTypeDto.Id);

                _mapper.Map(request.EmployeeTypeDto, EmployeeType);

                await _unitOfWork.Repository<EmployeeType>().Update(EmployeeType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Update Successfull";
                response.Id = EmployeeType.Id;
            }
            return response;
        }
    }
}
