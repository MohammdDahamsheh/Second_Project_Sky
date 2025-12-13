using Applecation.Repository;
using Domain.DTOs;
using Domain.Entity;
using Domain.Entity.Bids;
using Domain.Entity.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Service
{
    public class EvaluationService
    {
        private readonly IUnitOfWork<WinBid> evaluationUnitOfWork;
        private readonly IUnitOfWork<Tender> tenderUnitOfWork;
        private readonly IUnitOfWork<Bid> bidUnitOfWork;
        public EvaluationService(IUnitOfWork<WinBid> evaluationUnitOfWork, IUnitOfWork<Tender> tenderUnitOfWork, IUnitOfWork<Bid> bidUnitOfWork)
        {
            this.evaluationUnitOfWork = evaluationUnitOfWork;
            this.tenderUnitOfWork = tenderUnitOfWork;
            this.bidUnitOfWork = bidUnitOfWork;
        }
        public async Task<WinBid> addEvaluationForTender(int tenderId, WinBidDTO winBidDTO) { 
            var tender= await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderId);
            var bid= await bidUnitOfWork.GetRepository.GetByIdAsync(winBidDTO.bidId);

            var result= new WinBid
            {
                tenderId=tenderId,
                bidId=winBidDTO.bidId,
                awardedDate=DateOnly.FromDateTime(DateTime.Now),
                comments=winBidDTO.comments
            };
            await evaluationUnitOfWork.GetRepository.AddAsync(result);
            await evaluationUnitOfWork.SaveChangesAsync();


            return result;

        }

        public async Task<IEnumerable<Bid>> getBidsByTenderId(int tenderId)
        {
            var tender = await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderId);
            if (tender == null)
            {
                throw new Exception("Tender not found");
            }

            var bids = (from b in bidUnitOfWork.GetRepository.GetAllAsync().Result
                        where b.tenderId == tenderId
                        select b).ToList();
            return bids;
        }
        public async Task<IEnumerable<Bid>> getBidsDecresingPrice(int tenderId)
        {
            var tender = await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderId);
            var bids = (from b in bidUnitOfWork.GetRepository.GetAllAsync().Result
                        where b.tenderId == tenderId
                        orderby b.totalBidAmount ascending
                        select b).ToList();
            if (bids == null || bids.Count == 0)
            {
                throw new Exception("No bids found for this tender");
            }
            return bids;


        }



    }
}
