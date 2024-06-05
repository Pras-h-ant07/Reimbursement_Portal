using AutoMapper;
using PresentationLayer.Model;
using SharedLayer.BusinessEntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Mapper
{
    public class modelMapper: Profile
    {
        public modelMapper() : base("modelMapper")
        {
            CreateMap<ApprovalModel,ApprovalEntitiesDTO>().ReverseMap();
            CreateMap<SignUpModel,SignUpEntitiesDTO>().ReverseMap();
            CreateMap<ReimbursementModel,ReimbursementEntitiesDTO>().ReverseMap();
        }
    }
}
