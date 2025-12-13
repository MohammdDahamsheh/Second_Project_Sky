using Applecation.Repository;
using Domain.DTOs;
using Domain.Entity;
using Domain.Entity.Bids;
using Infrastrucure;

namespace Applecation.Service
{
    public class BidService
    {
        
        private readonly TenderContext context;
        private readonly IUnitOfWork<Bid> unitOfWork;
        private readonly IUnitOfWork<PaymentTerms> unitOfWorkPayment;
        private readonly IUnitOfWork<Tender> unitOfWorkTender;
        private readonly IUnitOfWork<BidDocument> unitOfWorkBidDocument;
        private readonly IUnitOfWork<FinancialProposal> unitOfWorkFinancialProposal;
        private readonly IUnitOfWork<TechnicalProposal> unitOfWorkTechnicalProposal;

        public BidService(TenderContext context, IUnitOfWork<Bid> unitOfWork, IUnitOfWork<PaymentTerms> unitOfWorkPayment, IUnitOfWork<Tender> unitOfWorkTender, IUnitOfWork<BidDocument> unitOfWorkBidDocument, IUnitOfWork<FinancialProposal> unitOfWorkFinancialProposal, IUnitOfWork<TechnicalProposal> unitOfWorkTechnicalProposal)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.unitOfWorkPayment = unitOfWorkPayment;
            this.unitOfWorkTender = unitOfWorkTender;
            this.unitOfWorkBidDocument = unitOfWorkBidDocument;
            this.unitOfWorkFinancialProposal = unitOfWorkFinancialProposal;
            this.unitOfWorkTechnicalProposal = unitOfWorkTechnicalProposal;
        }

        public async Task<Bid> addBid(BidDTO bid)
        {
            var tender = await unitOfWorkTender.GetRepository.GetByIdAsync(bid.tenderId);
            var paymentTerms = new PaymentTerms
            {
                PenaltiesForDelays = bid.PenaltiesForDelays,
                termMethod = bid.termMethod,
                PaymentScheduleAdvance = bid.PaymentScheduleAdvance,
                PaymentScheduleUponMilestoneCompletion = bid.PaymentScheduleUponMilestoneCompletion,
                PaymentScheduleAdvanceFinalApproval = bid.PaymentScheduleAdvanceFinalApproval
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

        public async Task<BidDocument> addDocument(BidDocumentDTO bidDocumentDTO)
        {
            var bid = await unitOfWork.GetRepository.GetByIdAsync(bidDocumentDTO.bidId);
            
            var bidDoc = (from bd in context.bidDocuments
                            where bd.bidId == bidDocumentDTO.bidId
                            select bd);
            if (bidDoc != null) {

                var tp= (from t in context.technicalProposals
                          where t.TechnicalProposalId == bidDoc.First().technicalProposalId
                         select t).First();
                
                tp.technicalApproachDescription = bidDocumentDTO.technicalApproachDescription;
                tp.methodologyDescription = bidDocumentDTO.methodologyDescription;
                tp.proposedSolution = bidDocumentDTO.proposedSolution;


                bidDoc.First().companyRegistrationCertificate = bidDocumentDTO.companyRegistrationCertificate;
                bidDoc.First().taxComplianceCertificate = bidDocumentDTO.taxComplianceCertificate;
                bidDoc.First().financialStatementsLast_2Years = bidDocumentDTO.financialStatementsLast_2Years;
                await unitOfWork.SaveChangesAsync();
                return bidDoc.First();


            }
            else
            {
                var technicalProposal = new TechnicalProposal
                {
                    technicalApproachDescription = bidDocumentDTO.technicalApproachDescription,
                    methodologyDescription = bidDocumentDTO.methodologyDescription,
                    proposedSolution = bidDocumentDTO.proposedSolution
                };
                var bidDocument = new BidDocument
                {
                    bidId = bidDocumentDTO.bidId,
                    companyRegistrationCertificate = bidDocumentDTO.companyRegistrationCertificate,
                    taxComplianceCertificate = bidDocumentDTO.taxComplianceCertificate,
                    financialStatementsLast_2Years = bidDocumentDTO.financialStatementsLast_2Years,
                    technicalProposalId = technicalProposal.TechnicalProposalId
                };
                context.bidDocuments.Add(bidDocument);
                await unitOfWork.SaveChangesAsync();
                return bidDocument;
            }

            

        }
        public async Task <FinancialProposal>addFinancialProposal(FinancialProposalDTO financialProposalDTO)
        {
            var bidDocument = await unitOfWorkBidDocument.GetRepository.GetByIdAsync(financialProposalDTO.bidDocumentId);

            var financialProposal = new FinancialProposal
            {
                bidDocumentId = financialProposalDTO.bidDocumentId,
                itemDescription = financialProposalDTO.itemDescription,
                quantity = financialProposalDTO.quantity,
                unitPrice = financialProposalDTO.unitPrice,
                totalPrice = financialProposalDTO.unitPrice * financialProposalDTO.quantity
            };
            await unitOfWorkFinancialProposal.GetRepository.AddAsync(financialProposal);
            await unitOfWork.SaveChangesAsync();
            return financialProposal;
        }
        

    
    }
}
