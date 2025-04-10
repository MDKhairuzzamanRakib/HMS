using AutoMapper;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Application.DTOs.GuestInfos;
using Hms.Domain.BasicSetup;
using Hms.Domain.GuestInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region BasicSetup
            CreateMap<BloodGroup, CreateCommonBasicSetupDto>().ReverseMap();
            CreateMap<BloodGroup, CommonBasicSetupDto>().ReverseMap();

            CreateMap<CategoryType, CreateCommonBasicSetupDto>().ReverseMap();
            CreateMap<CategoryType, CommonBasicSetupDto>().ReverseMap();

            CreateMap<Gender, CreateCommonBasicSetupDto>().ReverseMap();
            CreateMap<Gender, CommonBasicSetupDto>().ReverseMap();

            CreateMap<Country, CreateCommonBasicSetupDto>().ReverseMap();
            CreateMap<Country, CommonBasicSetupDto>().ReverseMap();

            #endregion

            #region GuestInfo
            CreateMap<GuestInfo, CreateGuestInfoDto>().ReverseMap();
            CreateMap<GuestInfo, GuestInfoDto>().ReverseMap();
            #endregion
        }
    }
}
