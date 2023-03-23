using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExercise.DTOs;
using FinalExercise.Services;

namespace FinalExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionsController : ControllerBase
    {
        private readonly ICommissionService _service;

        public CommissionsController(ICommissionService service)
        {
            _service = service;
        }

        // GET: api/Commisions
        [HttpPost]
        public async Task<ActionResult> AddCommission(CommissionRequestDTO commissionRequest)
        {
            var response = await _service.AddCommission(commissionRequest);

            if (response.Message.Equals("NotFound"))
                return NotFound();
            if (response.Message.Equals("BadRequest"))
                return BadRequest();
            else
                return Ok(response.Data);

        }

        // GET: api/Commissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommissionDTO>>> GetCommissions() 
        {
            var response = await _service.GetCommissions();
            return Ok(response);
        } 


        // DELETE: api/Commissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommission(int id)
        {
            var response = await _service.DeleteCommission(id);
            if (response.Message.Equals("NotFound"))
                return NotFound();
            else 
                return Ok("Commission Deleted");
        }

    }

}