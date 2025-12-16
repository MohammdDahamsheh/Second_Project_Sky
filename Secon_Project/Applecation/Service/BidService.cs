using Applecation.Repository;
using Domain.DTOs;
using Domain.Entity;
using Domain.Entity.Bids;
using Domain.Response;
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

        public async Task<BidResponse> addBid(BidDTO bid)
        {
            // Check if the tender exists
            var tender = await unitOfWorkTender.GetRepository.GetByIdAsync(bid.tenderId);
            var paymentTerms = new PaymentTerms
            {
                PenaltiesForDelays = bid.PenaltiesForDelays,
                termMethod = bid.termMethod,
                
                PaymentScheduleAdvance = bid.PaymentScheduleAdvance,
                PaymentScheduleUponMilestoneCompletion = bid.PaymentScheduleUponMilestoneCompletion,
                PaymentScheduleAdvanceFinalApproval = bid.PaymentScheduleAdvanceFinalApproval,
                
            };
            await unitOfWorkPayment.GetRepository.AddAsync(paymentTerms);


            var bidEntity = new Bid
            {
                tenderId = bid.tenderId,
                CompanyName = bid.CompanyName,
                address = bid.address,
                paymentTerms = paymentTerms,
                totalBidAmount= bid.totalBidAmount
                //userId= 1 
            };
             await unitOfWork.GetRepository.AddAsync(bidEntity);

            await unitOfWork.SaveChangesAsync();
            var username =  (from u in context.Users where u.userId == bidEntity.userId select u.userName).First();
            var result = new BidResponse
            {

                bidId = bidEntity.bidId,
                tenderId = bidEntity.tenderId,
                CompanyName = bidEntity.CompanyName,
                address = bidEntity.address,
                totalBidAmount = bidEntity.totalBidAmount,
                termMethod = paymentTerms.termMethod,
                PenaltiesForDelays = paymentTerms.PenaltiesForDelays,
                PaymentScheduleAdvance = paymentTerms.PaymentScheduleAdvance,
                PaymentScheduleUponMilestoneCompletion = paymentTerms.PaymentScheduleUponMilestoneCompletion,
                PaymentScheduleAdvanceFinalApproval = paymentTerms.PaymentScheduleAdvanceFinalApproval,
                username= username
            };


                return result;
        }

        public async Task<BidDocumentResponse> addDocument(BidDocumentDTO bidDocumentDTO)
        {
            var bid = await unitOfWork.GetRepository.GetByIdAsync(bidDocumentDTO.bidId);
            
            var bidDoc = (from bd in context.bidDocuments
                            where bd.bidId == bidDocumentDTO.bidId
                            select bd).FirstOrDefault();
            if (bidDoc != null) {

                var tp= (from t in context.technicalProposals
                          where t.TechnicalProposalId == bidDoc.technicalProposalId
                         select t).First();
                
                tp.technicalApproachDescription = bidDocumentDTO.technicalApproachDescription;
                tp.methodologyDescription = bidDocumentDTO.methodologyDescription;
                tp.proposedSolution = bidDocumentDTO.proposedSolution;


                bidDoc.companyRegistrationCertificate = bidDocumentDTO.companyRegistrationCertificate;
                bidDoc.taxComplianceCertificate = bidDocumentDTO.taxComplianceCertificate;
                bidDoc.financialStatementsLast_2Years = bidDocumentDTO.financialStatementsLast_2Years;
                await unitOfWork.SaveChangesAsync();
                var bidDocResponse = new BidDocumentResponse
                {
                    bidDocumentId = bidDoc.bidDocumentId,
                    bidId = bidDoc.bidId,
                    technicalProposalId = bidDoc.technicalProposalId,
                    companyRegistrationCertificate = bidDoc.companyRegistrationCertificate,
                    taxComplianceCertificate = bidDoc.taxComplianceCertificate,
                    financialStatementsLast_2Years = bidDoc.financialStatementsLast_2Years
                };
                return bidDocResponse;


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
                    technicalProposal = technicalProposal
                };
                await unitOfWorkBidDocument.GetRepository.AddAsync(bidDocument);
                await unitOfWork.SaveChangesAsync();
                var bidDocResponse = new BidDocumentResponse
                {
                    bidDocumentId = bidDocument.bidDocumentId,
                    bidId = bidDocument.bidId,
                    technicalProposalId = bidDocument.technicalProposalId,
                    companyRegistrationCertificate = bidDocument.companyRegistrationCertificate,
                    taxComplianceCertificate = bidDocument.taxComplianceCertificate,
                    financialStatementsLast_2Years = bidDocument.financialStatementsLast_2Years
                };
                return bidDocResponse;
            }

            

        }
        public async Task <FinancialProposalResponse>addFinancialProposal(FinancialProposalDTO financialProposalDTO)
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
            var response = new FinancialProposalResponse
            {
                FinancialProposalId = financialProposal.financialProposalId,

                itemDescription = financialProposal.itemDescription,
                quantity = financialProposal.quantity,
                unitPrice = financialProposal.unitPrice,
                total = financialProposal.totalPrice,
                bidDocumentId = financialProposal.bidDocumentId

            };
            return response;
        }
        public async Task<string> declaretion(int bidId) {
            //check is the bid is found:
            var bid = await unitOfWork.GetRepository.GetByIdAsync(bidId);
            var dec=(from d in context.declaretions
                     where d.bidId == bidId
                     select d).FirstOrDefault();
            if (dec != null)
            { 
                return dec.declarationText;
            }
            var username = (from u in context.Users where u.userId==bid.userId select u.userName).First();

             var declaration = new Declaretion
            {
                bidId = bidId,
                declarationText =$"We, {bid.CompanyName} , hereby submit this" +
                $" bid in response to the above-mentioned tender." +
                $" \r\nWe confirm that: \r\n•" +
                $" All provided information is accurate and complete." +
                $" \r\n• We comply with all tender requirements. \r\n•" +
                $" We understand and accept the terms and conditions " +
                $"set forth in the tender document. \r\n" +
                $"Authorized Signatory: {username} \r\n" +
                $"Date: {DateOnly.FromDateTime(DateTime.Now)}" 
                
            };
           await context.declaretions.AddAsync(declaration);
            await unitOfWork.SaveChangesAsync();
            return declaration.declarationText;

        }

        

    }
}
