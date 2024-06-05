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
    public class signUpController : ControllerBase
    {
        private readonly BusinessFacadeClass _business_facade_class;

        public signUpController(BusinessFacadeClass value)
        {
            this._business_facade_class = value;
        }

        // get employee by id
        [HttpGet]
        public IActionResult GetAnEmployee(int EmployeeId)
        {
            return Ok(_business_facade_class.GetAnEmployee(EmployeeId));
        }

        //create employee
        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee(SignUpEntity SignUpEntity)
        {
            _business_facade_class.CreateEmployee(SignUpEntity);
            return Created("Created", "In database");
        }

        
    }
}
