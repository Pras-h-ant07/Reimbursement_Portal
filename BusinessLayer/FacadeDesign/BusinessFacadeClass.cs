using BusinessLayer.BusinessLogic;
using DataAccessLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FacadeDesign
{
    public class BusinessFacadeClass
    {
        private readonly SignUpOperations _signUp_operations;
        private readonly ReimbursementOperations _reimbursement_operations;
        private readonly ApprovalOperations _approval_operations;

        public BusinessFacadeClass(SignUpOperations signUp, ReimbursementOperations reimbursement, ApprovalOperations approvalp)
        {
            this._signUp_operations = signUp;
            this._reimbursement_operations = reimbursement;
            this._approval_operations = approvalp;
        }

        public ReimbursementEntity GetReimbursement(ReimbursementEntity ReimbursementEntity)
        {
            return _approval_operations.GetReimbursement(ReimbursementEntity);
        }
        public IEnumerable<object> getAllPendingRequests()
        {
            return _approval_operations.getAllPendingRequests();
        }

        public IEnumerable<object> getAllAcceptedRequests()
        {
            return _approval_operations.getAllAcceptedRequests();
        }

        public IEnumerable<object> getAllDeclinedRequests()
        {
            return _approval_operations.getAllDeclinedRequests();
        }
        public void DeclineReimbursement(int id)
        {
            _approval_operations.DeclineReimbursement(id);
        }

        public void ApproveReimbursement(ApprovalEntity ApprovalEntity)
        {
            _approval_operations.ApproveReimbursement(ApprovalEntity);
        }

        public void CreateReimbursement(ReimbursementEntity ReimbursementEntity)
        {
            _reimbursement_operations.CreateReimbursement(ReimbursementEntity);
        }
        public IEnumerable<object> getReimbursementsforEmployee(int EmployeeId)
        {
            return _reimbursement_operations.getReimbursementsforEmployee(EmployeeId);
        }

        public void DeleteReimbursement(int EmployeeId)
        {
            _reimbursement_operations.DeleteReimbursement(EmployeeId);
        }
        public void EditReimbursement(ReimbursementEntity reim)
        {
            _reimbursement_operations.EditReimbursement(reim);
        }

        public void CreateEmployee(SignUpEntity SignUpEntity)
        {
            _signUp_operations.CreateEmployee(SignUpEntity);
        }

        public SignUpEntity GetAnEmployee(int EmployeeId)
        {
            return _signUp_operations.GetAnEmployee(EmployeeId);
        }

        public bool Login(SignUpEntity SignUpEntity)
        {
            return _signUp_operations.Login(SignUpEntity);
        }
        public int GetUserByEmail(string email)
        {
            return _signUp_operations.GetEmployeeByEmail(email);
        }

        public string GetIsApproverByEmail(string email)
        {
            return _signUp_operations.GetIsApproverByEmail(email);
        }

        public SignUpEntity GetAllEmployeeDetailByEmail(string email)
        {
            return _signUp_operations.GetAllEmployeeDetailByEmail(email);
        }

        
    }
}
