using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Exceptions;
using Hms.Application.Features.BasicSetup.Citys.Requests.Commands;
using Hms.Application.Responses;
using Hms.Domain.BasicSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.Citys.Handlers.Commands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var City = await _unitOfWork.Repository<City>().Get(request.Id);

            if (City == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
            }

            await _unitOfWork.Repository<City>().Delete(City);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Delete Successfull";
            response.Id = City.Id;

            return response;
        }
    }
}
