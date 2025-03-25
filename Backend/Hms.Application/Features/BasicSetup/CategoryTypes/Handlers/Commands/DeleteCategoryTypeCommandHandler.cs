using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Exceptions;
using Hms.Application.Features.BasicSetup.CategoryTypes.Requests.Commands;
using Hms.Application.Responses;
using Hms.Domain.BasicSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.BasicSetup.CategoryTypes.Handlers.Commands
{
    public class DeleteCategoryTypeCommandHandler : IRequestHandler<DeleteCategoryTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(DeleteCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var CategoryType = await _unitOfWork.Repository<CategoryType>().Get(request.Id);

            if (CategoryType == null)
            {
                response.Success = false;
                response.Message = "Data Not Found";
            }

            await _unitOfWork.Repository<CategoryType>().Delete(CategoryType);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Delete Successfull";
            response.Id = CategoryType.Id;

            return response;
        }
    }
}
