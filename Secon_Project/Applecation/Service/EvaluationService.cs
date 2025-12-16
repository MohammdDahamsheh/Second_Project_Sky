using Applecation.Repository;
using Domain.DTOs;
using Domain.Entity;
using Domain.Entity.Bids;
using Domain.Entity.Evaluation;
using Domain.Response;
using Infrastrucure;


namespace Applecation.Service
{
    public class EvaluationService
    {
        private readonly IUnitOfWork<WinBid> evaluationUnitOfWork;
        private readonly IUnitOfWork<Tender> tenderUnitOfWork;
        private readonly IUnitOfWork<Bid> bidUnitOfWork;
        private readonly IUnitOfWork<WinBid> winBidUnitOfWork;
        private readonly TenderContext context;
        public EvaluationService(TenderContext context,IUnitOfWork<WinBid> evaluationUnitOfWork, IUnitOfWork<WinBid> winBidUnitOfWork, IUnitOfWork<Tender> tenderUnitOfWork, IUnitOfWork<Bid> bidUnitOfWork)
        {
            this.evaluationUnitOfWork = evaluationUnitOfWork;
            this.tenderUnitOfWork = tenderUnitOfWork;
            this.bidUnitOfWork = bidUnitOfWork;
            this.winBidUnitOfWork = winBidUnitOfWork;
            this.context= context;
        }
        public async Task<WinBidResponse> addEvaluationForTender(int tenderId, WinBidDTO winBidDTO) { 
            var tender= await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderId);
            var bid= await bidUnitOfWork.GetRepository.GetByIdAsync(winBidDTO.bidId);
            var winBid =  (from w in context.winBids
                                where w.tenderId == tenderId 
                                select w
                                ).FirstOrDefault();
            if (winBid != null) {
                throw new Exception("The tender was Evaluation in last time .....");
            }

            var winbid= new WinBid
            {
                tenderId=tenderId,
                bidId=winBidDTO.bidId,
                awardedDate=DateOnly.FromDateTime(DateTime.Now),
                comments=winBidDTO.comments
            };
            await evaluationUnitOfWork.GetRepository.AddAsync(winbid);
            await evaluationUnitOfWork.SaveChangesAsync();

            var result = new WinBidResponse
            {
                winBidId = winbid.winBidId,
                tenderId = tenderId,
                bidId = winbid.bidId,
                comments = winbid.comments,
                awardedDate = winbid.awardedDate
            };

            return result;

        }

        public async Task<IEnumerable<BidResponse>> getBidsByTenderId(int tenderId)
        {
            var tender = await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderId);

            var bids= await bidUnitOfWork.GetRepository.GetAllAsync();
            if (bids == null || bids.Count() == 0) {
                throw new Exception("There are no bids for this tender.....");
            }
           

            var result = (from b in context.bids
                          join u in context.Users
                          on b.userId equals u.userId
                          join p in context.paymentTerms 
                          on b.paymentTermsId equals p.paymentTermsId
                          where b.tenderId == tenderId
                          select new BidResponse { 
                            tenderId = b.tenderId,
                            bidId = b.bidId,
                            username=u.userName,
                            CompanyName=b.CompanyName,
                            address=b.address,
                            totalBidAmount=b.totalBidAmount,
                            termMethod=p.termMethod,
                            PaymentScheduleAdvance=p.PaymentScheduleAdvance,
                            PaymentScheduleAdvanceFinalApproval=p.PaymentScheduleAdvanceFinalApproval,
                            PaymentScheduleUponMilestoneCompletion = p.PaymentScheduleUponMilestoneCompletion,
                            PenaltiesForDelays = p.PenaltiesForDelays
                           }).ToList();
            return result;
        }
        public async Task<IEnumerable<BidResponse>> getBidsDecresingPrice(int tenderId)
        {
            //check the tender and the bids : 
            var tender = await tenderUnitOfWork.GetRepository.GetByIdAsync(tenderId);
            var bids=await bidUnitOfWork.GetRepository.GetAllAsync();
            var result = (from b in context.bids
                          join u in context.Users
                          on b.userId equals u.userId
                          join p in context.paymentTerms
                          on b.paymentTermsId equals p.paymentTermsId
                          where b.tenderId == tenderId
                          orderby b.totalBidAmount ascending
                          select new BidResponse
                          {
                              tenderId = b.tenderId,
                              bidId = b.bidId,
                              username = u.userName,
                              CompanyName = b.CompanyName,
                              address = b.address,
                              totalBidAmount = b.totalBidAmount,
                              termMethod = p.termMethod,
                              PaymentScheduleAdvance = p.PaymentScheduleAdvance,
                              PaymentScheduleAdvanceFinalApproval = p.PaymentScheduleAdvanceFinalApproval,
                              PaymentScheduleUponMilestoneCompletion = p.PaymentScheduleUponMilestoneCompletion,
                              PenaltiesForDelays = p.PenaltiesForDelays
                          }).ToList();
            return result;


        }



    }
}
