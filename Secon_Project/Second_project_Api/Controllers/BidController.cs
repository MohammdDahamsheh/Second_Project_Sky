using Applecation.Service;
using Applecation.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Second_project_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "BID")]
    public class BidController : ControllerBase
    {
        private readonly BidService bidService;
        public BidController(BidService bidService)
        {
            this.bidService = bidService;

        }
        [HttpPost("/bids")]
        public async Task<IActionResult> AddBid([FromBody] BidDTO bid)
        {
            var result = await bidService.addBid(bid,int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!));
            return Ok(result);
        }
        [HttpPost("/bids/documents")]
        public async Task<IActionResult> addDocumentBid([FromBody] BidDocumentDTO bidDocument)
        {
            var result = await bidService.addDocument(bidDocument);
            return Ok(result);
        }
        [HttpPost("/bids/financialProposal")]
        public async Task<IActionResult> addFinancialProposal([FromBody] FinancialProposalDTO financialProposalDTO)
        {
            var result = await bidService.addFinancialProposal(financialProposalDTO);
            return Ok(result);
        }

        [HttpGet("/bids/declaration/{bidId}")]
        public async Task<IActionResult> getDeclaration(int bidId)
        {
            var result = await bidService.declaretion(bidId);
            return Ok(result);
        }
        
    }
}
