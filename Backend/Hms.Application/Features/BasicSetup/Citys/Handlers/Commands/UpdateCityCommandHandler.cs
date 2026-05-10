using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Citys.Requests.Commands;
using Hms.Application.Features.Common;
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
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.CityDto.Name;

            if (_existenceChecker.EntityExists<City>("Name", name, "Id", request.CityDto.Id))
            {
                response.Success = false;
                response.Message = $"Update Failed '{name}' already exists.";
            }
            else
            {
                var City = await _unitOfWork.Repository<City>().Get(request.CityDto.Id);

                _mapper.Map(request.CityDto, City);

                await _unitOfWork.Repository<City>().Update(City);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Update Successfull";
                response.Id = City.Id;
            }
            return response;
        }
    }
}
