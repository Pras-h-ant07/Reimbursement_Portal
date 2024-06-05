using DataAccessLayer.EntityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.BusinessEntitiesDTO
{
    public class ReimbursementEntitiesDTO
    {

        [Key]
        public int ClaimId { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        public string ReimbursementType { get; set; }

        [Required(ErrorMessage = "Required")]
        public int RequestedValue { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(10)]
        public string Currency { get; set; }

        [Required]
        [StringLength(50)]
        public string RequestPhase { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptAttached { get; set; }

        public int SignUp_Id { get; set; }
    }
}
