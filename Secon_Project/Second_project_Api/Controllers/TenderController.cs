using Applecation.Service;
using Domain.DTOs;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Second_project_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenderController : ControllerBase
    {
        private readonly TenderService tenderService;
        public TenderController(TenderService tenderService)
        {
            this.tenderService = tenderService;
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
        [HttpPost("/Tenders")]
        public async Task<IActionResult> AddTender([FromBody] TenderDTO tender)
        {
            var result = await tenderService.AddTender(tender);
            if (result)
            {
                return Ok("Tender added successfully");
            }
            return BadRequest("Failed to add tender");
        }

        [HttpPut("/Tenders")]
        public async Task<IActionResult> UpdateTender([FromBody] Tender tender)
        {
            var result = await tenderService.UpdateTender(tender);
            if (result)
            {
                return Ok("Tender updated successfully");
            }
            return BadRequest("Failed to update tender");
        }


        [HttpPost("/Tenders/Documents")]
        public async Task<IActionResult> addDocumentTender([FromBody] TenderDocumentDTO tenderDocument)
        {
            return Ok(await tenderService.addTenderDocument(tenderDocument));
        }
        [HttpGet("/Tenders/Open")]
        public async Task<IActionResult> GetOpenTenders()
        {
            var tenders = await tenderService.getOpenTenders();
            return Ok(tenders);

        }
        [HttpPost("/Tenders/eligibilityCriterias")]
        public async Task<IActionResult> addEligibilityCriterias([FromBody] EligibilityCriteriaDTO eligibilityCriteriaDTO)
        {
            var result = await tenderService.AddEligibilityCriteria(eligibilityCriteriaDTO);
            return Ok(result);
        }
        [HttpGet("/Tenders/eligibilityCriterias/{tenderId}")]
        public async Task<IActionResult> getEligibilityCriterias(int tenderId)
        {
            var result = await tenderService.getEligibilityCriterias(tenderId);
            return Ok(result);
        }
    }
}
