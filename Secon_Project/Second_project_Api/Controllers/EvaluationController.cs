using Applecation.Service;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Second_project_Api.Controllers
{
    public class EvaluationController:ControllerBase
    {
        private readonly EvaluationService evaluationService;
  
        public EvaluationController(EvaluationService evaluationService)
        {
            this.evaluationService = evaluationService;
        }
        [HttpPost("/Evaluation/{bidId}")]
        public async Task<IActionResult> evaluateBid(int bidId, [FromBody] WinBidDTO evaluationDTO)
        {
            var result = await evaluationService.addEvaluationForTender(bidId, evaluationDTO);
            return Ok(result);
        }
        [HttpGet("/Evaluations/TenderBids/{tenderId}")]
        public async Task<IActionResult> getBidsByTenderId(int tenderId)
        {
            var result = await evaluationService.getBidsByTenderId(tenderId);
            return Ok(result);
        }
        [HttpGet("/Evaluations/TenderBids/ascending/{tenderId}")]
        public async Task<IActionResult> getBidsByTenderIdAscending(int tenderId)
        {
            var result = await evaluationService.getBidsDecresingPrice(tenderId);
            return Ok(result);
        }
    }
}
