using Applecation.Repository;
using Domain.DTOs;
using Domain.Entity.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Service
{
    public class BidService
    {
        
        private readonly IUnitOfWork<Bid> unitOfWork;
        private readonly IUnitOfWork<PaymentTerms> unitOfWorkPayment;
        public BidService(IUnitOfWork<Bid> unitOfWork,IUnitOfWork<PaymentTerms> unitOfWorkPayment)
        {
            this.unitOfWork = unitOfWork;
            this.unitOfWorkPayment = unitOfWorkPayment;

        }

        public async Task<Bid> addBid(BidDTO bid)
        {
            var paymentTerms = new PaymentTerms
            {
                PenaltiesForDelays = bid.PenaltiesForDelays,
                termMethod = bid.termMethod
            };
           await unitOfWorkPayment.GetRepository.AddAsync(paymentTerms);


            var bidEntity = new Bid
            {
                tenderId = bid.tenderId,
                CompanyName = bid.CompanyName,
                address = bid.address,
                paymentTerms = paymentTerms
            };
             var result=await unitOfWork.GetRepository.AddAsync(bidEntity);

            await unitOfWork.SaveChangesAsync();


            return bidEntity;
        }

        public async Task<BidDocument> addDocument(BidDocumentDTO bidDocumentDTO) {
            var bid = await unitOfWork.GetRepository.GetByIdAsync(bidDocumentDTO.bidId);
            if (bid == null)
            {
                throw new Exception("Bid not found");
            }
            var bidDocument = new BidDocument
            {
                bidId = bidDocumentDTO.bidId,
                documentPath = bidDocumentDTO.documentPath
            };
            bid.addBidDocument(bidDocument);
            var result=await unitOfWork.SaveChangesAsync();
            return bidDocument;
        }
    
    }
}
