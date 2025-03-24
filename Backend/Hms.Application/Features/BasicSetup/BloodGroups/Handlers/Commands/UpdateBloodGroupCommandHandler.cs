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
    public class UpdateBloodGroupCommandHandler : IRequestHandler<UpdateBloodGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public UpdateBloodGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(UpdateBloodGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.BloodGroupDto.Name;

            if (_existenceChecker.EntityExists<BloodGroup>("Name", name, "Id", request.BloodGroupDto.Id))
            {
                response.Success = false;
                response.Message = $"Update Failed '{name}' already exists.";
            }
            else
            {
                var bloodGroup = await _unitOfWork.Repository<BloodGroup>().Get(request.BloodGroupDto.Id);

                _mapper.Map(request.BloodGroupDto, bloodGroup);

                await _unitOfWork.Repository<BloodGroup>().Update(bloodGroup);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Update Successfull";
                response.Id = bloodGroup.Id;
            }
            return response;
        }
    }
}
