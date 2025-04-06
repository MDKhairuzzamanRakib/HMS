using AutoMapper;
using Hms.Application.DTOs.Common.CommonBasicSetupDto;
using Hms.Domain.BasicSetup;
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
            CreateMap<BloodGroup, CommonBasicSetupDto>().ReverseMap();
            CreateMap<BloodGroup, CommonBasicSetupDto>().ReverseMap();

            CreateMap<CategoryType, CommonBasicSetupDto>().ReverseMap();
            CreateMap<CategoryType, CommonBasicSetupDto>().ReverseMap();
        }
    }
}
