using DataAccessLayer.Context;
using DataAccessLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessLogic
{
    public class ApprovalOperations
    {
        private readonly domainContext db;

        public ApprovalOperations(domainContext context)
        {
            this.db = context;
        }

        public IEnumerable<object> getAllPendingRequests()
        {
            return (from r in db.ReimbursementEntity

                    join e in db.SignUpEntity
                    on r.SignUp_Id equals e.SignUp_Id
                    where r.RequestPhase == "To be Processed"
                    select new
                    {
                        ClaimId = r.ClaimId,
                        ReimbursementType = r.ReimbursementType,
                        RequestedBy = e.Email,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        ReceiptAttached = r.ReceiptAttached,
                    }).ToList();
        }

        public void ApproveReimbursement(ApprovalEntity ApprovalEntity)
        {
            ReimbursementEntity r = db.ReimbursementEntity.FirstOrDefault(x => x.ClaimId == ApprovalEntity.ClaimId);
            r.RequestPhase = "Processed";
            db.ApprovalEntity.Add(ApprovalEntity);
            db.SaveChanges();
        }

        public ReimbursementEntity GetReimbursement(ReimbursementEntity ReimbursementEntity)
        {
            ReimbursementEntity result = db.ReimbursementEntity.FirstOrDefault(r => r.ClaimId == ReimbursementEntity.ClaimId);
            return result;
        }
        public IEnumerable<object> getAllAcceptedRequests()
        {
            return (from r in db.ReimbursementEntity

                    join e in db.SignUpEntity
                    on r.SignUp_Id equals e.SignUp_Id
                    where r.RequestPhase == "Processed"
                    select new
                    {
                        ClaimId = r.ClaimId,
                        ReimbursementType = r.ReimbursementType,
                        RequestedBy = e.Email,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        Receipt = r.ReceiptAttached,
                    }).ToList();
        }

        public void DeclineReimbursement(int EmployeeId)
        {
            ReimbursementEntity entity = db.ReimbursementEntity.FirstOrDefault(r => r.ClaimId == EmployeeId);
            entity.RequestPhase = "Declined";
            db.SaveChanges();
        }

        public IEnumerable<object> getAllDeclinedRequests()
        {
            return (from r in db.ReimbursementEntity

                    join e in db.SignUpEntity
                    on r.SignUp_Id equals e.SignUp_Id
                    where r.RequestPhase == "Declined"
                    select new
                    {
                        ClaimId = r.ClaimId,
                        ReimbursementType = r.ReimbursementType,
                        RequestedBy = e.Email,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        ReceiptAttached = r.ReceiptAttached,
                    }).ToList();
        }

    }
}
