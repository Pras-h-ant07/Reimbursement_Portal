using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityModel
{
    public class SignUpEntity
    {
        [Key]
        public int SignUp_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string PanNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Bank { get; set; }

        [Required]
        [StringLength(25)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(25)]
        public string IsApprover { get; set; }
    }
}
