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
            return Ok(await bidService.addDocument(bidDocument));
        }
        [HttpGet("/Bids/{id}    ")]
    }
}
