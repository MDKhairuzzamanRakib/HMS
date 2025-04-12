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
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public CreateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.CityDto.Name;

            if (_existenceChecker.EntityExists<City>("Name", name, "Id", request.CityDto.Id))
            {
                response.Success = false;
                response.Message = $"Creation Failed '{name}' already exists.";
            }
            else
            {
                var City = _mapper.Map<City>(request.CityDto);

                City = await _unitOfWork.Repository<City>().Add(City);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = City.Id;
            }
            return response;
        }
    }
}