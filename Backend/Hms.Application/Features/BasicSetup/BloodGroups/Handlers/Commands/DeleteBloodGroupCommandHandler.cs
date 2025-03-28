using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Exceptions;
using Hms.Application.Features.BasicSetup.BloodGroups.Requests.Commands;
using Hms.Application.Responses;
using Hms.Domain.BasicSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.BloodGroups.Handlers.Commands
{
    public class DeleteBloodGroupCommandHandler : IRequestHandler<DeleteBloodGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBloodGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(DeleteBloodGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var bloodGroup = await _unitOfWork.Repository<BloodGroup>().Get(request.Id);

            if (bloodGroup == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
            }

            await _unitOfWork.Repository<BloodGroup>().Delete(bloodGroup);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Delete Successfull";
            response.Id = bloodGroup.Id;

            return response;
        }
    }
}
