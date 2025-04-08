using AutoMapper;
using Hms.Application.Contracts.Persistence;
using Hms.Application.DTOs.GuestInfos;
using Hms.Application.Features.GuestInfos.Requests.Commands;
using Hms.Application.Responses;
using Hms.Domain.GuestInfos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Features.GuestInfos.Handlers.Commands
{
    public class CreateGuestInfoCommandHandler : IRequestHandler<CreateGuestInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateGuestInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGuestInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var guestInfoDto = _mapper.Map<GuestInfo>(request.GuestInfoDto);

            if (request.GuestInfoDto.PhotoFile != null)
            {
                var photoName = Path.GetFileName(request.GuestInfoDto.PhotoFile.FileName);
                string uniqueImageName = "Photo_" + request.GuestInfoDto.AspNetUserId + "_" + photoName;
                var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\images\\GuestPhoto", uniqueImageName);

                using (var photoSteam = new FileStream(photoPath, FileMode.Create))
                {
                    await request.GuestInfoDto.PhotoFile.CopyToAsync(photoSteam);
                }

                guestInfoDto.PhotoUrl = uniqueImageName;
            }

            await _unitOfWork.Repository<GuestInfo>().Add(guestInfoDto);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
