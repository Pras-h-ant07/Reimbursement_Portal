using DataAccessLayer.Context;
using DataAccessLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessLogic
{
    public class SignUpOperations
    {
        private readonly domainContext db;

        public SignUpOperations(domainContext context)
        {
            this.db = context;
        }

        //Login Operation
        public bool Login(SignUpEntity SignUpEntity)
        {
            SignUpEntity valid = db.SignUpEntity.FirstOrDefault(e => e.Email == SignUpEntity.Email && e.Password == SignUpEntity.Password);
            if (valid != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Create an Employee
        public void CreateEmployee(SignUpEntity SignUpEntity)
        {
            if (SignUpEntity.Email == "admin@gmail.com")
            {
                SignUpEntity.IsApprover = "Yes";
            }
            else
            {
                SignUpEntity.IsApprover = "No";
            }
            db.SignUpEntity.Add(SignUpEntity);
            db.SaveChanges();
        }

        //Get all Employee list
        public IEnumerable<SignUpEntity> GetAll()
        {
            IEnumerable<SignUpEntity> List = db.SignUpEntity;
            return db.SignUpEntity;
        }

        //GET all Employee details through Email 
        public SignUpEntity GetAllEmployeeDetailByEmail(string email)
        {
            SignUpEntity SignUpEntity = db.SignUpEntity.FirstOrDefault(e => e.Email == email);
            return SignUpEntity;
        }

        //GET Single Employee details through SignUp_Id 
        public SignUpEntity GetAnEmployee(int EmployeeId)
        {
            SignUpEntity SignUpEntity = db.SignUpEntity.FirstOrDefault(e => e.SignUp_Id == EmployeeId);
            return SignUpEntity;
        }

        //GET Employee SignUp_ID through email
        public int GetEmployeeByEmail(string email)
        {
            SignUpEntity SignUpEntity = db.SignUpEntity.FirstOrDefault(e => e.Email == email);
            return SignUpEntity.SignUp_Id;
        }

        //Misc Operations:
        public string GetIsApproverByEmail(string email)
        {
            SignUpEntity SignUpEntity = db.SignUpEntity.FirstOrDefault(e => e.Email == email);
            return SignUpEntity.IsApprover;
        }

    }
}
