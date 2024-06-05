using BusinessLayer.FacadeDesign;
using DataAccessLayer.EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reimbursementController : ControllerBase
    {
        private readonly BusinessFacadeClass _business_facade_class;

        public reimbursementController(BusinessFacadeClass value)
        {
            this._business_facade_class = value;
        }

        [HttpPost]
        [Route("CreateReimbursement")]
        public IActionResult CreateReimbursement([FromBody] ReimbursementEntity ReimbursementEntity)
        {
            _business_facade_class.CreateReimbursement(ReimbursementEntity);
            return Created("Successfully Created", "In Database");
        }
        [HttpGet]
        [Route("GetReimbursement/{id}")]
        public IActionResult GetReimbursement(int id)
        {
            ReimbursementEntity dto = new ReimbursementEntity();
            dto.ClaimId = id;
            return Ok(_business_facade_class.GetReimbursement(dto));
        }

        [HttpGet]
       [Route("getReimbursementsforEmployee/{id}")]
        public IActionResult getReimbursementsforEmployee(int id)
        {
            return Ok(_business_facade_class.getReimbursementsforEmployee(id));
        }
        [HttpGet]
        [Route("getAllPendingRequest")]
        public IActionResult getAllPendingRequest()
        {
            return Ok(_business_facade_class.getAllPendingRequests());
        }
        [HttpGet]
        [Route("getAllAcceptedRequest")]
        public IActionResult getAllAcceptedRequest()
        {
            return Ok(_business_facade_class.getAllAcceptedRequests());
        }
        [HttpGet]
        [Route("getAllDeclinedRequest")]
        public IActionResult getAllDeclinedRequest()
        {
            return Ok(_business_facade_class.getAllDeclinedRequests());
        }
        [HttpDelete]
        [Route("deleteReimbursement/{id}")]
        public IActionResult DeleteReimbursement(int id)
        {
            _business_facade_class.DeleteReimbursement(id);
            return Ok("Deleted");
        }

        [HttpPut]
        [Route("DeclineReimbursement")]
        public IActionResult DeclineReimbursement(declineRequestEntity decline)
        {
            _business_facade_class.DeclineReimbursement(decline.ClaimId);
            return Ok("Declined");
        }

        [HttpPost]
        [Route("ApproveReimbursement")]
        public IActionResult ApproveReimbursement(ApprovalEntity ApprovalEntity)
        {
            _business_facade_class.ApproveReimbursement(ApprovalEntity);
            return Ok("Approved");
        }

        [HttpPut]
        [Route("EditReimbursement")]
        public IActionResult EditReimbursement([FromBody] ReimbursementEntity model)
        {
            _business_facade_class.EditReimbursement(model);
            return Ok("Successfully Edited");
        }
    }
}
