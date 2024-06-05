using DataAccessLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.BusinessEntitiesDTO
{
    public class ApprovalEntitiesDTO
    {
        [Key]
        public int SignUp_Id { get; set; }

        public string ApprovedBy { get; set; }

        public int? ApprovedValue { get; set; }

        public string InternalNotes { get; set; }

        public int ClaimId { get; set; }
        public virtual ReimbursementEntity ReimbursementEntity { get; set; }
    }
}
