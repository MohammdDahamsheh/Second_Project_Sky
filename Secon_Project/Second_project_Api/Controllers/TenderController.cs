using Applecation.Service;
using Domain.DTOs;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Second_project_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "TENDER")]
    public class TenderController : ControllerBase
    {
        private readonly TenderService tenderService;
        public TenderController(TenderService tenderService)
        {
            this.tenderService = tenderService;
        }
        
        [HttpPost("/Tenders")]
        public async Task<IActionResult> AddTender([FromBody] TenderDTO tender)
        {
            var result = await tenderService.AddTender(tender,int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!));
            if (result)
            {
                return Ok("Tender added successfully");
            }
            return BadRequest("Failed to add tender");
        }
        [HttpPost("/Tenders/Documents")]
        public async Task<IActionResult> addDocumentTender([FromBody] TenderDocumentDTO tenderDocument)
        {
            return Ok(await tenderService.addTenderDocument(tenderDocument));
        }
        
        [HttpPost("/Tenders/eligibilityCriterias")]
        public async Task<IActionResult> addEligibilityCriterias([FromBody] EligibilityCriteriaDTO eligibilityCriteriaDTO)
        {
            var result = await tenderService.AddEligibilityCriteria(eligibilityCriteriaDTO);
            return Ok(result);
        }
        [HttpPut("/Tenders")]
        public async Task<IActionResult> UpdateTender([FromBody] UpdateTenderDTO tender)
        {
            var result = await tenderService.UpdateTender(tender);
            if (result)
            {
                return Ok("Tender updated successfully");
            }
            return BadRequest("Failed to update tender");
        }
        [HttpGet("/Tenders/Open")]
        public async Task<IActionResult> GetOpenTenders()
        {
            var tenders = await tenderService.getOpenTenders();
            return Ok(tenders);

        }
        [HttpGet("/Tenders/eligibilityCriterias/{tenderId}")]
        public async Task<IActionResult> getEligibilityCriterias(int tenderId)
        {
            var result = await tenderService.getEligibilityCriterias(tenderId);
            return Ok(result);
        }


        [HttpGet("/Tenders")]
        public async Task<IActionResult> GetAllTenders()
        {
            var tenders = await tenderService.GetAllTenders();
            return Ok(tenders);

        }
        [HttpGet("/Tenders/{id}")]
        public async Task<IActionResult> GetTenderById(int id)
        {
            var tender = await tenderService.GetTenderById(id);
            return Ok(tender);
        }


        [HttpGet("/Documents/{tenderId}")]
        public async Task<IActionResult> getTenderDocs(int tenderId) { 
        
            var result= await tenderService.getTenderDoc(tenderId);
            return Ok(result);
        }
    
    
    
    }

    
}
