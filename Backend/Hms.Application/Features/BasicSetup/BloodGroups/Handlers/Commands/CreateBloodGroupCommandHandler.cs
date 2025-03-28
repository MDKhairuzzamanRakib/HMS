using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.BloodGroups.Requests.Commands;
using Hms.Application.Features.Common;
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
    public class CreateBloodGroupCommandHandler : IRequestHandler<CreateBloodGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public CreateBloodGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(CreateBloodGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.BloodGroupDto.Name;

            if (_existenceChecker.EntityExists<BloodGroup>("Name", name, "Id", request.BloodGroupDto.Id))
            {
                response.Success = false;
                response.Message = $"Creation Failed '{name}' already exists.";
            }
            else
            {
                var bloodGroup = _mapper.Map<BloodGroup>(request.BloodGroupDto);

                bloodGroup = await _unitOfWork.Repository<BloodGroup>().Add(bloodGroup);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = bloodGroup.Id;
            }
            return response;
        }
    }
}