using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Exceptions;
using Hms.Application.Features.BasicSetup.Countrys.Requests.Commands;
using Hms.Application.Responses;
using Hms.Domain.BasicSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Countrys.Handlers.Commands
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var Country = await _unitOfWork.Repository<Country>().Get(request.Id);

            if (Country == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
            }

            await _unitOfWork.Repository<Country>().Delete(Country);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Delete Successfull";
            response.Id = Country.Id;

            return response;
        }
    }
}
