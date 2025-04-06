using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Genders.Requests.Commands;
using Hms.Application.Features.Common;
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
    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public UpdateGenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.GenderDto.Name;

            if (_existenceChecker.EntityExists<Gender>("Name", name, "Id", request.GenderDto.Id))
            {
                response.Success = false;
                response.Message = $"Update Failed '{name}' already exists.";
            }
            else
            {
                var Gender = await _unitOfWork.Repository<Gender>().Get(request.GenderDto.Id);

                _mapper.Map(request.GenderDto, Gender);

                await _unitOfWork.Repository<Gender>().Update(Gender);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Update Successfull";
                response.Id = Gender.Id;
            }
            return response;
        }
    }
}
