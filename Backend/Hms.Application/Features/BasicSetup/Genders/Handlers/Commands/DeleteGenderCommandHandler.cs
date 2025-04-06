using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Exceptions;
using Hms.Application.Features.BasicSetup.Genders.Requests.Commands;
using Hms.Application.Responses;
using Hms.Domain.BasicSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Genders.Handlers.Commands
{
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGenderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var Gender = await _unitOfWork.Repository<Gender>().Get(request.Id);

            if (Gender == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
            }

            await _unitOfWork.Repository<Gender>().Delete(Gender);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Delete Successfull";
            response.Id = Gender.Id;

            return response;
        }
    }
}
