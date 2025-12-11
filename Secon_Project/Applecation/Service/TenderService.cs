using Applecation.Repository;
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
        public async Task<bool> AddTender(Tender tender)
        {
            var result = await tenderUnitOfWork.GetRepository.AddAsync(tender);
            if (result)
            {
                await tenderUnitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateTender(int id,Tender tender)
        {
            var existingTender = await tenderUnitOfWork.GetRepository.GetByIdAsync(id);
            if (existingTender == null)
            {
                return false;
            }
            var result = await tenderUnitOfWork.GetRepository.UpdateAsync(tender);
            if (result)
            {
                await tenderUnitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
