using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.Features.BasicSetup.Countrys.Requests.Commands;
using Hms.Application.Features.Common;
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
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericExistenceChecker _existenceChecker;

        public CreateCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _existenceChecker = new GenericExistenceChecker(unitOfWork);
        }
        public async Task<BaseCommandResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var name = request.CountryDto.Name;

            if (_existenceChecker.EntityExists<Country>("Name", name, "Id", request.CountryDto.Id))
            {
                response.Success = false;
                response.Message = $"Creation Failed '{name}' already exists.";
            }
            else
            {
                var Country = _mapper.Map<Country>(request.CountryDto);

                Country = await _unitOfWork.Repository<Country>().Add(Country);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Country.Id;
            }
            return response;
        }
    }
}