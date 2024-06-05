using DataAccessLayer.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class domainContext :DbContext
    {
        public domainContext(DbContextOptions<domainContext> options) : base(options)
        {

        }
        public DbSet<ReimbursementEntity> ReimbursementEntity { get; set; }
        public DbSet<ApprovalEntity> ApprovalEntity { get; set; }
        public DbSet<SignUpEntity> SignUpEntity { get; set; }
    }
}
