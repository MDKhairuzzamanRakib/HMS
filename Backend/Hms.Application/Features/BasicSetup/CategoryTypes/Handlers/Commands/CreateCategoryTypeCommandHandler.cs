using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.CategoryTypes.Requests.Commands;
using Hms.Application.Features.Common;
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
    public class CreateCategoryTypeCommandHandler : IRequestHandler<CreateCategoryTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public CreateCategoryTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(CreateCategoryTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.CategoryTypeDto.Name;

            if (_existenceChecker.EntityExists<CategoryType>("Name", name, "Id", request.CategoryTypeDto.Id))
            {
                response.Success = false;
                response.Message = $"Creation Failed '{name}' already exists.";
            }
            else
            {
                var CategoryType = _mapper.Map<CategoryType>(request.CategoryTypeDto);

                CategoryType = await _unitOfWork.Repository<CategoryType>().Add(CategoryType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CategoryType.Id;
            }
            return response;
        }
    }
}