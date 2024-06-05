using BusinessLayer.FacadeDesign;
using DataAccessLayer.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly BusinessFacadeClass _business_facade_class;

        public loginController(BusinessFacadeClass value)
        {
            this._business_facade_class = value;
        }
        [HttpPost]
        [Route("Logins")]
        public IActionResult Login(SignUpEntity SignUpEntity)
        {
            if (_business_facade_class.Login(SignUpEntity) == true)
            {
                int id = _business_facade_class.GetUserByEmail(SignUpEntity.Email);
                string IsApprover = _business_facade_class.GetIsApproverByEmail(SignUpEntity.Email);
                return Ok(new
                {
                    signUp_Id = id,
                    isApprover = IsApprover,
                    status = true
                }
                );
            }
            return BadRequest("Invalid");
        }

        [HttpGet]
        [Route("emailAvailable/{email}")]

        public IActionResult EmailAvailable(string email)
        {

            var SignUpEntity = _business_facade_class.GetAllEmployeeDetailByEmail(email);
            System.Console.WriteLine(SignUpEntity);
            if (SignUpEntity == null)
            {
                return Ok(new
                {
                    available = true
                });
            }
            else return Ok(new
            {
                available = false
            });
        }
    }
}
