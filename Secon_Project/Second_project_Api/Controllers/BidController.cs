using Applecation.Service;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Second_project_Api.Controllers
{
    public class BidController : ControllerBase
    {
        private readonly BidService bidService;
        public BidController(BidService bidService)
        {
            this.bidService = bidService;

        }
        [HttpPost("/Bids")]
        public async Task<IActionResult> AddBid([FromBody] BidDTO bid)
        {
            var result = await bidService.addBid(bid);
            return Ok(result);
        }
        [HttpPost("/Bids/Documents")]
        public async Task<IActionResult> addDocumentBid([FromBody] BidDocumentDTO bidDocument)
        {
            var result = await bidService.addDocument(bidDocument);
            return Ok(result);
        }
        [HttpPost("/Bids/FinancialProposal")]
        public async Task<IActionResult> addFinancialProposal([FromBody] FinancialProposalDTO financialProposalDTO)
        {
            var result = await bidService.addFinancialProposal(financialProposalDTO);
            return Ok(result);
        }

        [HttpGet("/Bids/Declaration/{bidId}")]
        public async Task<IActionResult> getDeclaration(int bidId)
        {
            var result = await bidService.declaretion(bidId);
            return Ok(result);
        }
        
    }
}
