using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Exceptions;
using Hms.Application.Features.BasicSetup.EmployeeTypes.Requests.Commands;
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
    public class DeleteEmployeeTypeCommandHandler : IRequestHandler<DeleteEmployeeTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(DeleteEmployeeTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var EmployeeType = await _unitOfWork.Repository<EmployeeType>().Get(request.Id);

            if (EmployeeType == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
            }

            await _unitOfWork.Repository<EmployeeType>().Delete(EmployeeType);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Delete Successfull";
            response.Id = EmployeeType.Id;

            return response;
        }
    }
}
