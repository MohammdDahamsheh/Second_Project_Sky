using Application.Repository;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Servises
{
    public class TenderService
    {

        private  IUnitOfWork<Tender> unitOfWork;


        public TenderService(IUnitOfWork<Tender> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tender>> GetAllTendersAsync()
        {
            return await unitOfWork.Repository.GetAllAsync();
        }
        public async Task<Tender> GetTenderByIdAsync(int id)
        {
            return await unitOfWork.Repository.GetByIdAsync(id);
        }
        public async Task<bool> AddTenderAsync(Tender tender)
        {
            var result = await unitOfWork.Repository.AddAsync(tender);
            await unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
