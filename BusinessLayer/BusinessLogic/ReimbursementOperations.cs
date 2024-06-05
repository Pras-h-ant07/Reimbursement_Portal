using DataAccessLayer.Context;
using DataAccessLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessLogic
{
    public class ReimbursementOperations
    {
        private readonly domainContext db;

        public ReimbursementOperations(domainContext context)
        {
            this.db = context;
        }

        // C: Create
        public void CreateReimbursement(ReimbursementEntity Reimbursement)
        {
            Reimbursement.RequestPhase = "To be processed";
            if (Reimbursement.ReceiptAttached == "")
            {
                Reimbursement.ReceiptAttached = "No";
            }
            else
            {
                Reimbursement.ReceiptAttached = "Yes";
            }

            db.ReimbursementEntity.Add(Reimbursement);
            db.SaveChanges();
        }

        //R: Read
        public IEnumerable<object> getReimbursementsforEmployee(int EmployeeId)
        {
            return (from r in db.ReimbursementEntity
                    where r.SignUp_Id == EmployeeId
                    join q in db.ApprovalEntity
                    on r.ClaimId equals q.ClaimId
                    into dataTable
                    from data in dataTable.DefaultIfEmpty()
                    select new
                    {
                        ClaimId = r.ClaimId,
                        ReimbursementType = r.ReimbursementType,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        RequestPhase = r.RequestPhase,
                        RecieptAttached = r.ReceiptAttached,
                        ApprovedValue = data != null ? data.ApprovedValue : 0,
                        SignUp_Id = r.SignUp_Id
                    }).ToList().OrderByDescending(x => x.Date);
        }

        //U: Update
        public void EditReimbursement(ReimbursementEntity reimbursement)
        {
            ReimbursementEntity entity = db.ReimbursementEntity.FirstOrDefault(r => r.ClaimId == reimbursement.ClaimId);
            entity.Date = reimbursement.Date;
            entity.ReceiptAttached = reimbursement.ReceiptAttached;
            entity.Currency = reimbursement.Currency;
            entity.ReimbursementType = reimbursement.ReimbursementType;
            entity.RequestedValue = reimbursement.RequestedValue;

            db.SaveChanges();
        }

        //D: Delete
        public void DeleteReimbursement(int EmployeeId)
        {
            ReimbursementEntity entity = db.ReimbursementEntity.FirstOrDefault(r => r.ClaimId == EmployeeId);
            db.ReimbursementEntity.Remove(entity);
            db.SaveChanges();
        }

    }
}
