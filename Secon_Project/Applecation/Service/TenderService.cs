using Applecation.Repository;
using Domain.DTOs;
using Domain.Entity;


namespace Applecation.Service
{
    public class TenderService
    {
        private readonly IUnitOfWork<Tender> tenderUnitOfWork;
        public TenderService(IUnitOfWork<Tender> tenderUnitOfWork) 
        { this.tenderUnitOfWork = tenderUnitOfWork; }
        public async Task<IEnumerable<Tender>> GetAllTenders()
        {
            return await tenderUnitOfWork.GetRepository.GetAllAsync();
        }
        public async Task<Tender> GetTenderById(int id)
        {
            
            return await tenderUnitOfWork.GetRepository.GetByIdAsync(id);
        }
        public async Task<bool> AddTender(TenderDTO tender)
        {
            var tenderEntity = new Tender
            {
                tenderCategoryId = tender.tenderCategoryId,
                tenderTypeId = tender.tenderTypeId,
                closingDate = tender.closingDate,
                tenderTitle = tender.tenderTitle,
                tenderDescription = tender.tenderDescription,
                issueDate = DateOnly.FromDateTime(DateTime.Now),
                budget = tender.budget

            };
            var result = await tenderUnitOfWork.GetRepository.AddAsync(tenderEntity);
            if (result)
            {
                await tenderUnitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTender(Tender tender)
        {
            var existingTender = await tenderUnitOfWork.GetRepository.GetByIdAsync(tender.tenderId);
            if (existingTender == null)
            {
                throw new Exception("Tender not found");
            }
            var result = await tenderUnitOfWork.GetRepository.UpdateAsync(tender);
            if (result)
            {
                await tenderUnitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> addTenderDocument(TenderDocumentDTO tenderDocumentDTO) {
           
            var tender=await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderDocumentDTO.tenderId);
            if(tender == null) {
                throw new Exception("Tender not found");
            }
            var tenderDocument = new TenderDocument(
                tenderDocumentDTO.tenderId,
                tenderDocumentDTO.documentPath,
                tenderDocumentDTO.addBy
                );
            tender.AddTenderDocument(tenderDocument);
            await tenderUnitOfWork.SaveChangesAsync();

            return true;

        }

    }
}
