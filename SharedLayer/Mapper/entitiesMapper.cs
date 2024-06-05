using AutoMapper;
using DataAccessLayer.EntityModel;
using SharedLayer.BusinessEntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.Mapper
{
    public class entitiesMapper: Profile
    {
        public entitiesMapper() : base("entitiesMapper")
        {
            CreateMap<ApprovalEntitiesDTO, ApprovalEntity>().ReverseMap();
            CreateMap<SignUpEntitiesDTO, SignUpEntity>().ReverseMap();
            CreateMap<ReimbursementEntitiesDTO, ReimbursementEntity>().ReverseMap();
        }
    }
}
