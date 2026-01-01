using Applecation.Service;
using Applecation.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Second_project_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "EVALUATION")] 
    public class EvaluationController:ControllerBase
    {
        private readonly EvaluationService evaluationService;
  
        public EvaluationController(EvaluationService evaluationService)
        {
            this.evaluationService = evaluationService;
        }
        [HttpPost("/evaluations/{tenderId}")]
        public async Task<IActionResult> evaluateBid(int tenderId, [FromBody] WinBidDTO evaluationDTO)
        {
            var result = await evaluationService.addEvaluationForTender(tenderId, evaluationDTO);
            return Ok(result);
        }
        [HttpGet("/evaluations/tenderBids/{tenderId}")]
        public async Task<IActionResult> getBidsByTenderId(int tenderId)
        {
            var result = await evaluationService.getBidsByTenderId(tenderId);
            return Ok(result);
        }
        [HttpGet("/evaluations/tenderBids/sort/price-asc/{tenderId}")]
        public async Task<IActionResult> getBidsByTenderIdAscending(int tenderId)
        {
            var result = await evaluationService.getBidsDecresingPrice(tenderId);
            return Ok(result);
        }
        [HttpGet("/evaluations/bidDocuments/{bidId}")]
        public async Task<IActionResult> getDocBids(int bidId) { 

            var result=await evaluationService.getBidDoc(bidId);
            return Ok(result);

        }
        [HttpGet("/evaluations/einancialProposal/{bidId}")]
        public async Task<IActionResult> getFinancialProposal(int bidId) {
            return Ok(await evaluationService.GetFinancialProposalResponses(bidId));
        }
    }
}
