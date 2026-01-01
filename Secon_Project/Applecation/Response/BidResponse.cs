using Domain.Entity;
using Domain.Entity.Bids;
using Domain.Entity.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Response
{
    public class BidResponse
    {
        public int bidId { get; set; }
        public int tenderId { get; set; }
        //public int userId { get; set; }
        public string username { get; set; }
        public string CompanyName { get; set; }
        public string address { get; set; }
        public decimal totalBidAmount { get; set; }
        public string termMethod { get; set; }
        public string PenaltiesForDelays { get; set; }
        public string PaymentScheduleAdvance { get; set; }
        public string PaymentScheduleUponMilestoneCompletion { get; set; }
        public string PaymentScheduleAdvanceFinalApproval { get; set; }

        public BidResponse() { }
    }
}
